using Sdl.Core.Settings;

namespace python_caller
{
    public class MyCustomBatchTaskSettings : SettingsGroup
    {

        public string SettingsPythonPath => GetSetting<string>(nameof(SettingsPythonPath));
        public string SettingsPythonFile => GetSetting<string>(nameof(SettingsPythonFile));
        public string SettingsPythonFileForDebug => GetSetting<string>(nameof(SettingsPythonFileForDebug));
        public string SettingsSkippingKeyword => GetSetting<string>(nameof(SettingsSkippingKeyword));



        public bool SettingsUseReturnText => GetSetting<bool>(nameof(SettingsUseReturnText));
        public bool SettingsUseSkippingKeyword => GetSetting<bool>(nameof(SettingsUseSkippingKeyword));
        public bool SettingsChangeStatus => GetSetting<bool>(nameof(SettingsChangeStatus));



        public int SettingsApplyModeIndex => GetSetting<int>(nameof(SettingsApplyModeIndex));
        public int SettingsStatusIndex => GetSetting<int>(nameof(SettingsStatusIndex));
        public int SettingsFilterStatusIndex => GetSetting<int>(nameof(SettingsFilterStatusIndex));
        public int SettingsReturnTextUsageIndex => GetSetting<int>(nameof(SettingsReturnTextUsageIndex));




        public int SettingsLimitRangeStart => GetSetting<int>(nameof(SettingsLimitRangeStart));
        public int SettingsLimitRangeEnd => GetSetting<int>(nameof(SettingsLimitRangeEnd));


        protected override object GetDefaultValue(string settingId)
        {
            switch (settingId)
            {
                case nameof(SettingsPythonPath):
                    return (string)"";
                case nameof(SettingsPythonFile):
                    return (string)"";
                case nameof(SettingsPythonFileForDebug):
                    return (string)"";
                case nameof(SettingsSkippingKeyword):
                    return (string)"__None__";

                case nameof(SettingsUseReturnText):
                    return (bool)true;
                case nameof(SettingsUseSkippingKeyword):
                    return (bool)false;
                case nameof(SettingsChangeStatus):
                    return (bool)false;

                case nameof(SettingsApplyModeIndex):
                    return (int)0;
                case nameof(SettingsStatusIndex):
                    return (int)0;
                case nameof(SettingsFilterStatusIndex):
                    return (int)0;
                case nameof(SettingsReturnTextUsageIndex):
                    return (int)0;

                case nameof(SettingsLimitRangeStart):
                    return (int)1;
                case nameof(SettingsLimitRangeEnd):
                    return (int)0;

                default:
                    return base.GetDefaultValue(settingId);
            }
        }

    }

}
