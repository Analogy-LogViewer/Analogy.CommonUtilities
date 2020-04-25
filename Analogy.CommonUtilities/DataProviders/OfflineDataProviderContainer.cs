using System;
using System.Collections.Generic;

namespace Analogy.CommonUtilities
{
    [Serializable]
    public class OfflineDataProviderContainer
    {
        public Guid ID { get; } = new Guid("E1696270-97BE-489F-9440-453BEA1AB7B8");
        public string OptionalTitle { get; } = string.Empty;
        public bool UseCustomColors { get; set; } = false;
        public bool CanSaveToLogFile { get; } = false;
        public string FileOpenDialogFilters => UserSettingsManager.UserSettings.Settings.FileOpenDialogFilters;
        public string FileSaveDialogFilters { get; } = string.Empty;
        public IEnumerable<string> SupportFormats => UserSettingsManager.UserSettings.Settings.SupportFormats;
        public string InitialFolderFullPath { get; } = Environment.CurrentDirectory;
        public bool DisableFilePoolingOption { get; } = false;
    }
}
