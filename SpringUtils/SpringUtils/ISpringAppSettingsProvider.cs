using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringUtils
{
    public interface ISpringAppSettingsProvider
    {
        IDictionary<string, string> GetAllSettings();
        T GetSetting<T>(string key);
        void SetSetting<T>(string key, T value);
    }
}
