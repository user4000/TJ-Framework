using System;
using TJFramework;
using System.Threading.Tasks;
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

      //TJFrameworkManager.FrameworkSettings.Save();
    }
  }
}