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
    private void SetChildFormSettings(RadForm radForm)
    {
      radForm.Dock = DockStyle.Fill;
      radForm.FormBorderStyle = FormBorderStyle.None;
      radForm.Visible = true;
      radForm.BringToFront();
    }

    public void AddForm<T>(string pageText, bool tabEnabled, bool tabVisible) where T : RadForm, new()
    {
      string pageName = GetFormName<T>();
      TJChildForm childForm = TJChildForm.Create<T>(pageName, pageText, tabEnabled, tabVisible);
      if (childForm.IncorrectPageName == false)
        QueueChildForms.Enqueue(childForm);
    }

    private void AddFormToPage(TJChildForm childForm)
    {
      if (MainPageViewManager.PageExists(childForm.PageName)) return;
      if (childForm.IncorrectPageName) return;

      RadPageViewPage page = new RadPageViewPage()
      {
        Name = childForm.PageName
      };

      MainPageViewManager.Add(page);
      MainPageViewManager.Add(childForm);

      page.Text = childForm.PageText;
      MainPageViewManager.SetPageStandardView(page);

      childForm.ChildForm.TopLevel = false; /* It is very important */

      SetChildFormSettings(childForm.ChildForm);
      page.Controls.Add(childForm.ChildForm);

      page.Item.MinSize = new Size(TJFrameworkManager.FrameworkSettings.TabMinimumWidth, 0);

      page.Item.Visibility = childForm.FlagTabVisible ? ElementVisibility.Visible : ElementVisibility.Collapsed;

      if (childForm.FlagTabEnabled == false)
      {
        page.Item.Enabled = false; // Похоже что свойство Enabled действует одновременно и на  page.Item и на page  //
      }

      if ((childForm.FlagTabVisible) && (MainPageView.Visible)) page.Refresh();

      CheckIsSettingsForm(childForm.ChildForm);
      CheckIsLogForm(childForm.ChildForm);
      CheckIsExitForm(childForm.ChildForm);
    }

    internal void CreateFormsFromQueue()
    {
      foreach (TJChildForm childForm in QueueChildForms)
      {
        AddFormToPage(childForm);  /* then we create other child forms */
      }

      QueueChildForms.Clear();

      //Pages.GotoPage(StartPageName);
    }
  }
}