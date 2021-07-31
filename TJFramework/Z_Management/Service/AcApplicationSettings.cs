using System;
using TJFramework.ApplicationSettings;

namespace TJFramework
{
  public partial class TJService
  {
    private void SetCurrentSettings(TJStandardApplicationSettings inputSettings) => CurrentApplicationSettings = inputSettings ?? CurrentApplicationSettings;

    internal void ConfigureApplicationSettings(TJStandardApplicationSettings settings)
    {
      ProjectDefaultApplicationSettings = settings;
      SetCurrentSettings(settings);
    }

    /// <summary>
    /// Use Assembly.GetExecutingAssembly().GetName().Name as an argument
    /// </summary>
    public void CreateApplicationSettings<T>(string SettingSubFolderName = "") where T : TJStandardApplicationSettings, new()
    {
      TJFrameworkManager.SetSubFolderForSettings(SettingSubFolderName);
      T settingsDefault = new T(); // Create instance of concrete user settings //
      T localSettingsCurrent = settingsDefault;
      /* Since JSON Serializer cannot save attributes of members of [Settings] class we need this workaround */
      try { localSettingsCurrent = TJStandardUserSettingsLoader<T>.LoadFromJsonFile(); }
      catch { localSettingsCurrent = settingsDefault; }

      CurrentApplicationSettings = localSettingsCurrent;
      ConfigureApplicationSettings(localSettingsCurrent);
    }
  }
}