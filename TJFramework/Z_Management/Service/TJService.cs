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
    public string GetFormName<T>() where T : RadForm => typeof(T).FullName;

    internal bool CheckPage<T>(string pageName) where T : RadForm => pageName == GetFormName<T>();

    internal void CreateMainPageView() => MainPageView = MainPageViewManager.Create(MainForm);

    internal Image GetImageByMessageType(MsgType MessageType) => FormLog.ImageIcons.Images[GetIndexByMessageType(MessageType)];

    public void StartPage<T>() where T : RadForm
    {
      string TypeOfForm = GetFormName<T>();
      if (TypeOfForm == GetFormName<FxExit>()) return;
      if (TypeOfForm == GetFormName<FxLog>()) return;
      if (TypeOfForm == GetFormName<FxMain>()) return;
      StartPageName = TypeOfForm;
    }

    internal void CheckIsExitForm(RadForm radForm)
    {
      if ((radForm is FxExit) && (FormExit == null))
      {
        FormExit = (FxExit)radForm;
        FormExit.BtnExit.Click += new EventHandler(EventButtonExitClick);
      }
    }

    internal void CheckIsLogForm(RadForm radForm)
    {
      if ((radForm is FxLog) && (FormLog == null))
      {
        FormLog = (FxLog)radForm;
        AlertService = new TJAlertService(this, FormLog);
      }
    }

    internal void CheckIsSettingsForm(RadForm radForm)
    {
      if ((ProjectDefaultApplicationSettings != null) && (radForm is FxSettings) && (FormSettings == null))
      {
        FormSettings = (FxSettings)radForm;
        TJStandardApplicationSettings loadedSettings = null;
        try
        {
          loadedSettings = CurrentApplicationSettings;
          SetCurrentSettings(loadedSettings); // Set just loaded settings as current settings //
        }
        catch (Exception ex)
        {
          ProjectDefaultApplicationSettings.LinkToPropertyGrid(FormSettings.GxProperty);
          Log.Save(MsgType.Error, "An error has occured during loading application settings.", "");
          Log.Save(ex, "method name = [IsSettingsForm]");
        }
        FormSettings.AcceptLoadedSettings(loadedSettings);
      }
    }

    internal void CreateFormLog() => AddForm<FxLog>(TJFrameworkManager.FrameworkSettings.HeaderFormLog, true, true);

    internal void CreateFormSettings() => AddForm<FxSettings>(TJFrameworkManager.FrameworkSettings.HeaderFormSettings, true, true);

    internal void CreateFormExit() => AddForm<FxExit>(TJFrameworkManager.FrameworkSettings.HeaderFormExit, true, true);


    public void SetMainPageViewOrientation(StripViewAlignment Alignment) => MainPageViewManager.SetMainPageViewTabOrientation(Alignment);


    internal void SetEventMainPageViewSelectedPageChanged()
    {
      MainPageView.SelectedPageChanged += new EventHandler(EventSelectedPageChanged);
    }
  }
}