using System;
using TJFramework.Form;

namespace TJFramework
{
  public partial class TJService
  {
    private void EventMainFormLoad(object sender, EventArgs e)
    {
      //PrepareToWorkStep1();
      //MainForm.Text = MainForm.Text + " < FormLoad >";
      //RadMessageBox.Show("EventMainFormLoad");
    }

    internal void EventMainFormShown(object sender, EventArgs e)
    {
      //PrepareToWorkStep2();
      //MainForm.Text = MainForm.Text + " < FormShown >";
      //RadMessageBox.Show("EventMainFormShown");      
    }

    private async void EventSelectedPageChanged(object sender, EventArgs e)
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
        if (FormExit.ExitWithoutConfirmation) await MainExit();
      }
      //---------------------------------------------------------------------------------------------------------//
    }
  }
}