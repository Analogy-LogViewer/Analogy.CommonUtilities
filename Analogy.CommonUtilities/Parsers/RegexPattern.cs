using System;

namespace Analogy.CommonUtilities.Parsers
{
    [Serializable]
    public class RegexPattern
    {
        public string Pattern { get; set; }
        public string DateTimeFormat { get; set; }
        public bool IsSet => !string.IsNullOrEmpty(Pattern) && !string.IsNullOrEmpty(DateTimeFormat);
        public RegexPattern()
        {
            Pattern = string.Empty;
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss,fff";

        }
        public RegexPattern(string pattern, string dateTimeFormat)
        {
            Pattern = pattern;
            DateTimeFormat = dateTimeFormat;
        }
    }
}
