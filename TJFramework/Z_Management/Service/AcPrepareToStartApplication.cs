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
      if (FlagPrepareToWorkStep1) return; // These events must be executed only one time //

      FlagPrepareToWorkStep1 = true;

      EventMainFormLoadBeforeAnyFormIsCreated?.Invoke();

      CreateFormLog();

      CreateFormExit();

      EventMainFormLoadBeforeAnyCustomFormIsCreated?.Invoke();

      CreateFormsFromQueue(); // Create all of the child forms in the Queue //
    }


    internal void PrepareToWorkStep2()
    {
      if (FlagPrepareToWorkStep2) return; // These events must be executed only one time //

      FlagPrepareToWorkStep2 = true;

      EventBeforeAnyFormStartHandlerLaunched?.Invoke();

      MainPageViewManager.LaunchStartHandlerOfEachChildForm();

      SetEventMainPageViewSelectedPageChanged();

      EventAfterAllFormsAreCreated?.Invoke();

      if (MainForm.MainPageView.Visible == false)
      {
        Pages.GotoPage(StartPageName);
        MainForm.MainPageView.Visible = true;
      }

      MainPageView.BringToFront();
      CheckSelectedPage();
    }

    private void CheckSelectedPage()
    {
      // Если пользователь указал стартовую страницу, а она не является текущей, то сделаем её текущей //
      var page = Pages.GetPageByUniqueName(StartPageName);
      if (page == null) MainPageView.SelectedPage = null;
      if ((page != null) && (MainPageView.SelectedPage != page))
        MainPageView.SelectedPage = page;
    }
  }
}
