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
      string PageName = MainPageView.SelectedPage.Name;

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