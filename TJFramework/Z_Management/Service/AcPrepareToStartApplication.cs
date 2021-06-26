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

    internal void PrepareToWorkStep1()
    {
      EventMainFormLoadBeforeAnyFormIsCreated?.Invoke();

      //Application.DoEvents();
      CreateFormLog();

      //Application.DoEvents();
      CreateFormExit();

      //Application.DoEvents();
      EventMainFormLoadBeforeAnyCustomFormIsCreated?.Invoke();

      //Application.DoEvents();

      CreateFormsFromQueue(); // Create all of the child forms in the Queue //
    }


    internal void PrepareToWorkStep2()
    {
      if (CounterEventFormShow > 0) return; // These events must be executed only one time //

      CounterEventFormShow++;

      //Application.DoEvents();
      EventBeforeAnyFormStartHandlerLaunched?.Invoke();

      //Application.DoEvents();
      MainPageViewManager.LaunchStartHandlerOfEachChildForm();

      SetEventMainPageViewSelectedPageChanged();

      Application.DoEvents();
      EventAfterAllFormsAreCreated?.Invoke();

      Application.DoEvents();
      if (MainForm.MainPageView.Visible == false)
      {
        Pages.GotoPage(StartPageName);
        MainForm.MainPageView.Visible = true;
      }


      MainPageView.BringToFront();
    }
  }
}
