using System.Drawing;
using TJFramework.Form;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Collections.Generic;

namespace TJFramework
{
  public class TJPageView
  {
    private RadPageView MainPageView { get; set; } = null;

    private FxMain MainForm { get; set; } = null;

    internal StripViewAlignment OrientationStripMainPageView { get; private set; } = StripViewAlignment.Top;

    internal Dictionary<string, TJChildForm> DictionaryChildForms = new Dictionary<string, TJChildForm>();

    public bool PageExists(string PageName) => DictionaryChildForms.ContainsKey(PageName);

    internal RadPageView Create(FxMain mainForm)
    {
      if (MainPageView == null)
      {
        MainForm = mainForm;

        /*
        Здесь закомментирован вариант, в котором MainPageView создаётся с помощью кода.
        Сейчас принят другой вариант 2021-01-29, в котором данный элемент создан в дизайнере главной формы.

        MainPageView = new RadPageView();
        mainForm.StartPosition = FormStartPosition.CenterScreen;
        mainForm.Controls.Add(MainPageView);
        MainPageView.Dock = DockStyle.Fill;
        MainPageView.Location = new Point(0, 0);
        */

        //------------------------------------------------------------------------------------
        mainForm.MainFormMenu.Visible = false;

        mainForm.PnMainTop.MaximumSize = new Size(0, 50);
        mainForm.PnMainSide.MaximumSize = new Size(400, 0);

        mainForm.PnMainTop.MinimumSize = new Size(0, mainForm.PnMainTop.Size.Height);
        mainForm.PnMainSide.MinimumSize = new Size(mainForm.PnMainSide.Size.Width, 0);

        mainForm.PnMainTop.Visible = false;
        mainForm.PnMainSide.Visible = false;

        mainForm.SplitterMainHorizontal.Visible = false;
        mainForm.SplitterMainVertical.Visible = false;
        //------------------------------------------------------------------------------------



        MainPageView = mainForm.MainPageView;

        MainPageView.Font = TJFrameworkManager.FrameworkSettings.PageViewFont;

        if (TJFrameworkManager.FrameworkSettings.MainPageViewReducePadding) MainPageView.Padding = new Padding(-5, 5, -5, -5); // new Padding(-5, 2, -5, -5);

        SetPageViewStripProperties(MainPageView);

        MainPageView.ItemSizeMode = TJFrameworkManager.FrameworkSettings.ItemSizeMode;
        if (MainPageView.ItemSizeMode != PageViewItemSizeMode.Individual)
          MainPageView.ItemSize = TJFrameworkManager.FrameworkSettings.PageViewItemSize;
      }
      return MainPageView;
    }

    private void SetPageViewStripProperties(RadPageView pageView)
    {
      RadPageViewStripElement element = (RadPageViewStripElement)pageView.GetChildAt(0);

      element.ShowItemPinButton = false;
      element.StripButtons = StripViewButtons.Scroll; // Scroll by default;
      element.ItemAlignment = StripViewItemAlignment.Near;
      element.ItemFitMode = StripViewItemFitMode.FillHeight;
      element.ShowItemCloseButton = false;
      element.ItemSpacing = TJFrameworkManager.FrameworkSettings.PageViewItemSpacing;
      //element.ItemSizeMode = PageViewItemSizeMode.Individual;
      // If user set orientation before creating of [RadPageView] we can apply this setting now since the object exists //
      SetMainPageViewTabOrientation(OrientationStripMainPageView);
    }

    /// <summary>
    /// Valid argument values = TOP, LEFT, RIGHT, BOTTOM
    /// </summary>
    internal void SetMainPageViewTabOrientation(StripViewAlignment StripOrientation)
    {
      if (MainPageView == null) { OrientationStripMainPageView = StripOrientation; return; }

      PageViewContentOrientation ItemOrienation =
        ((StripOrientation == StripViewAlignment.Left) || (StripOrientation == StripViewAlignment.Right))
        ? PageViewContentOrientation.Horizontal : PageViewContentOrientation.Auto;

      ((RadPageViewStripElement)(this.MainPageView.GetChildAt(0))).StripAlignment = StripOrientation;
      ((RadPageViewStripElement)(this.MainPageView.GetChildAt(0))).ItemContentOrientation = ItemOrienation;
    }

    internal void SetPageStandardView(RadPageViewPage page)
    {
      page.ItemSize = new SizeF(120F, 30);
      page.Location = new Point(10, 10);
      page.TextAlignment = ContentAlignment.MiddleCenter;
    }

    public RadPageViewPage GetPageByUniqueName(string pageUniqueName)
    {
      foreach (RadPageViewPage p in MainPageView.Pages) if (p.Name == pageUniqueName) return (p); return null;
    }

    public string GetUniquePageName<T>() where T : RadForm
    {
      string PageName = string.Empty;
      TJChildForm childForm = null;

      foreach (KeyValuePair<string, TJChildForm> entry in DictionaryChildForms)
      {
        childForm = entry.Value;
        if (childForm != null)
          if (childForm.ChildForm is T)
          {
            PageName = entry.Key; break;
          }
      }
      return PageName;
    }

    public string GetUniquePageName(string FormTypeName)
    {
      string PageName = string.Empty;
      TJChildForm childForm = null;

      foreach (KeyValuePair<string, TJChildForm> entry in DictionaryChildForms)
      {
        childForm = entry.Value;
        if (childForm != null)
          if (childForm.ChildForm.GetType().FullName == FormTypeName)
          {
            PageName = entry.Key; break;
          }
      }
      return PageName;
    }

    public bool IsPageSelected(string pageUniqueName)
    {
      if (PageExists(pageUniqueName) == false) return false;
      return (MainPageView.SelectedPage == GetPageByUniqueName(pageUniqueName));
    }

    public bool IsPageSelected<T>() where T : RadForm
    {
      return IsPageSelected(GetUniquePageName<T>());
    }

    public void GotoPage(string pageUniqueName)
    {
      if (PageExists(pageUniqueName))
      {
        RadPageViewPage page = GetPageByUniqueName(pageUniqueName);
        if (page != null) MainPageView.SelectedPage = page;
      }
    }

    public void GotoPage<T>() where T : RadForm
    {
      string PageName = GetUniquePageName<T>(); GotoPage(PageName);
    }

    public void EnablePage(string pageUniqueName, bool Enable)
    {
      if (PageExists(pageUniqueName))
      {
        RadPageViewPage page = GetPageByUniqueName(pageUniqueName);
        if ((page != null) && (page.Enabled != Enable)) page.Enabled = Enable;
      }
    }

    public void EnablePage<T>(bool Enable) where T : RadForm
    {
      string PageName = GetUniquePageName<T>(); EnablePage(PageName, Enable);
    }

    public void ShowPage(string pageUniqueName, bool Visible)
    {
      if (PageExists(pageUniqueName))
      {
        RadPageViewPage page = GetPageByUniqueName(pageUniqueName);
        if (page != null) page.Item.Visibility = Visible ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;
      }
    }

    public void ShowPage<T>(bool Show) where T : RadForm
    {
      string PageName = GetUniquePageName<T>(); ShowPage(PageName, Show);
    }

    public T GetRadForm<T>() where T : RadForm
    {
      T radForm = null;
      TJChildForm childForm = null;

      foreach (KeyValuePair<string, TJChildForm> entry in DictionaryChildForms)
      {
        childForm = entry.Value;
        if (childForm != null)
          if (childForm.ChildForm is T)
          {
            try { radForm = (T)childForm.ChildForm; } catch { };
            break;
          }
      }
      return radForm;
    }

    internal void Add(TJChildForm childForm) => DictionaryChildForms.Add(childForm.PageName, childForm);

    internal void Add(RadPageViewPage page) => MainPageView.Pages.Add(page);

    internal void LaunchStartHandlerOfEachChildForm()
    {
      foreach (KeyValuePair<string, TJChildForm> entry in DictionaryChildForms)
        entry.Value.LaunchStartHandler();
    }

    internal void LaunchCloseHandlerOfEachChildForm()
    {
      foreach (KeyValuePair<string, TJChildForm> entry in DictionaryChildForms)
        entry.Value.LaunchEndHandler();
    }
  }
}
