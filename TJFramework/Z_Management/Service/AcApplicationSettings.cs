using System;
using System.Drawing;
using TJFramework.Form;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Threading.Tasks;
using System.Collections.Generic;
using TJFramework.ApplicationSettings;
using static TJFramework.Logger.Manager;
using static TJFramework.TJFrameworkManager;

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
