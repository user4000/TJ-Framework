using System;
using TJFramework;
using System.Threading;
using TJFramework.Form;
using System.Windows.Forms;
using System.Threading.Tasks;
using TJFramework.ApplicationSettings;
using static TJFramework.Logger.Manager;
using static TJFramework.TJFrameworkManager;

namespace TJFramework
{
  public partial class TJService
  {

    private void EventButtonExitClick(object sender, EventArgs e)
    {
      FormExit.BtnExit.Enabled = false;
      FormExit.BtnExit.Visible = false;
      CloseMainForm();
    }


    internal void CloseMainForm()
    {
      UserHasClickedExitButton = true;
      MainForm.Close();
    }

    private async Task MainExit_OLD_VERSION()
    {
      UserHasClickedExit = true;

      EventBeforeMainFormClose?.Invoke();

      if (FuncBeforeMainFormClose != null)
      {

        // VisualEffectFadeOut();

        /*
        while (MainForm.Opacity > 0.0)
        {
          await Task.Delay(20);
          MainForm.Opacity -= 0.1;
        }
        */

        //MainForm.Opacity = 0;

        /*
        try
        {
          MainForm.ShowInTaskbar = false;
        }
        catch
        {

        }
        */

        Task task = FuncBeforeMainFormClose();
        if (task != null) await task;

      }

      MainPageViewManager.LaunchCloseHandlerOfEachChildForm();

      TJFrameworkManager.FrameworkSettings.Save();

      // if (FuncBeforeMainFormClose == null) VisualEffectFadeOut();
    }

    internal async Task MainExit()
    {
      UserHasClickedExit = true;

      EventBeforeMainFormClose?.Invoke();

      if (FuncBeforeMainFormClose != null)
      {
        Task task = FuncBeforeMainFormClose();
        if (task != null) await task;
      }

      MainPageViewManager.LaunchCloseHandlerOfEachChildForm();

      TJFrameworkManager.FrameworkSettings.Save();
    }
  }
}