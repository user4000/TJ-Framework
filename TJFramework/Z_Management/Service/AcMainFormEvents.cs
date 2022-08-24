using System;
using TJFramework.Form;
using System.Threading.Tasks;
using Telerik.WinControls;

namespace TJFramework
{
  public partial class TJService
  {
    private void EventMainFormLoad(object sender, EventArgs e)
    {

    }

    internal void EventMainFormShown(object sender, EventArgs e)
    {
  
    }

    private void EventSelectedPageChanged(object sender, EventArgs e)
    {
      string PageName = string.Empty;

      if ((MainPageView != null) && (MainPageView.SelectedPage != null))
      {
        PageName = MainPageView.SelectedPage.Name;
      }

      if (EventPageChanged != null) EventPageChanged.Invoke(PageName);

      //---------------------------------------------------------------------------------------------------------//
      if (CheckPage<FxSettings>(PageName)) // Настройки //
      {
        FormSettings.EventUserVisitedThisPage();
      }
      //---------------------------------------------------------------------------------------------------------//
      if (CheckPage<FxLog>(PageName)) // Журнал сообщений //
      {
        FormLog.EventUserVisitedThisPage();
      }
      //---------------------------------------------------------------------------------------------------------//
      if (CheckPage<FxExit>(PageName)) // Выход //
      {
        //RadMessageBox.Show($"EventSelectedPageChanged  TEST:   ConfirmExitButtonText = {TJFrameworkManager.FrameworkSettings.ConfirmExitButtonText}");

        if (FormExit.ExitWithoutConfirmation)
        {
          CloseMainForm();
        }
        else
        {
          FormExit.EventUserVisitedThisPage();
        }
      }
      //---------------------------------------------------------------------------------------------------------//
    }
  }
}