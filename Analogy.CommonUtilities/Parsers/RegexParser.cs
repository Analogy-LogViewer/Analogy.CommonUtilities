using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.CommonUtilities.Parsers
{
    public class RegexParser
    {
        private AnalogyLogMessage _current;
        private RegexPattern _lastUsedPattern;
        private readonly List<AnalogyLogMessage> _messages = new List<AnalogyLogMessage>();
        private readonly List<RegexPattern> _logPatterns;
        private IAnalogyLogger Logger { get; }
        private IEnumerable<RegexPattern> LogPatterns
        {
            get
            {
                if (_lastUsedPattern != null)
                    yield return _lastUsedPattern;
                var oldLastUsedPattern = _lastUsedPattern;
                foreach (var logPattern in _logPatterns)
                {
                    //skip last used pattern (returned first)
                    if (oldLastUsedPattern == logPattern) continue;
                    _lastUsedPattern = logPattern;
                    yield return _lastUsedPattern;
                }
            }
        }

        public IEnumerable<string> RegexMembers { get; }

        public RegexParser(List<RegexPattern> logPatterns, IAnalogyLogger logger)
        {
            _logPatterns = logPatterns;
            Logger = logger;
            RegexMembers = new List<string>
            {
                "Date", "ID", "Text", "Category", "Source", "MethodName", "FileName", "LineNumber", "Class", "Level",
                "Module", "ProcessID", "Thread"
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        public void ParseLine(string line)
        {
            var entry = ParseEntry(line);
            if (entry != null)
            {
                _current = entry;
                _messages.Add(_current);
            }
            else
            {
                if (_current == null)
                {
                    _current = new AnalogyLogMessage { Text = line };
                }
                else
                {
                    _current.Text += Environment.NewLine + line;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private AnalogyLogMessage ParseEntry(string line)
        {

            foreach (var logPattern in LogPatterns)
            {
                var result = TryParse(line, logPattern, out AnalogyLogMessage message);
                if (result)
                    return message;

            }
            return null;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryParse(string line, RegexPattern regex, out AnalogyLogMessage message)
        {
            try
            {
                Match match = Regex.Match(line, regex.Pattern,
                    RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
                if (match.Success)
                {
                    string thread = null;
                    if (match.Groups["thread"].Success)
                    {
                        thread = match.Groups["thread"].Value;
                    }

                    string process = null;
                    if (match.Groups["process"].Success)
                    {
                        process = match.Groups["process"].Value;
                    }

                    var m = new AnalogyLogMessage()
                    {
                        Date = DateTime.ParseExact(match.Groups["date"].Value, regex.DateTimeFormat,
                            CultureInfo.InvariantCulture),
                        Thread = thread != null ? int.Parse(thread) : 0,
                        ProcessID = process != null ? int.Parse(process) : 0,
                        Source = match.Groups["logger"].Value,
                        Text = match.Groups["message"].Value
                    };
                    switch (match.Groups["level"].Value)
                    {
                        case "OFF":
                            m.Level = AnalogyLogLevel.Disabled;
                            break;
                        case "TRACE":
                            m.Level = AnalogyLogLevel.Trace;
                            break;
                        case "DEBUG":
                            m.Level = AnalogyLogLevel.Debug;
                            break;
                        case "INFO":
                            m.Level = AnalogyLogLevel.Event;
                            break;
                        case "WARN":
                            m.Level = AnalogyLogLevel.Warning;
                            break;
                        case "ERROR":
                            m.Level = AnalogyLogLevel.Error;
                            break;
                        case "FATAL":
                            m.Level = AnalogyLogLevel.Critical;
                            break;
                        default:
                            m.Level = AnalogyLogLevel.Unknown;
                            break;
                    }

                    message = m;
                    return true;
                }

                message = null;
                return false;
            }
            catch (Exception e)
            {
                string error = $"Error parsing line; {e.Message}";
                Logger.LogException(e, nameof(RegexParser), error);
                message = new AnalogyLogMessage(error, AnalogyLogLevel.Error, AnalogyLogClass.General, nameof(RegexParser));
                return false;
            }
        }
        public async Task<List<AnalogyLogMessage>> ParseLog(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler)
        {
            using (StreamReader reader = File.OpenText(fileName))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    ParseLine(line);
                    if (token.IsCancellationRequested)
                    {
                        messagesHandler.AppendMessages(_messages, fileName);
                        return _messages;
                    }
                }
            }
            messagesHandler.AppendMessages(_messages, fileName);
            return _messages;
        }

    }
}

