using System;
using System.Drawing;
using TJFramework.Form;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Collections.Generic;


namespace TJFramework
{
  public partial class TJPageView
  {
    private RadPageView MainPageView { get; set; } = null;

    private FxMain MainForm { get; set; } = null;

    internal StripViewAlignment OrientationStripMainPageView { get; private set; } = StripViewAlignment.Top;

    internal Dictionary<string, TJChildForm> DictionaryChildForms = new Dictionary<string, TJChildForm>();

    public bool PageExists(string PageName) => DictionaryChildForms.ContainsKey(PageName);

    internal void Add(TJChildForm childForm)
    {
      try
      {
        DictionaryChildForms.Add(childForm.PageName, childForm);
      }
      catch 
      {
        if (childForm != null)
          RadMessageBox.Show($"Ошибка при добавлении в словарь значения {childForm.PageName}");
        throw;
      }
    }

    internal void Add(RadPageViewPage page)
    {    
      MainPageView.Pages.Add(page);
      MainPageView.SelectedPage = null;
      // -------- Application.DoEvents(); Эта инструкция приводит к глюкам в вызывающем приложении //
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


    internal void LaunchStartHandlerOfEachChildForm()
    {
      foreach (KeyValuePair<string, TJChildForm> entry in DictionaryChildForms)
      { 
        entry.Value.LaunchStartHandler();
        //Application.DoEvents();
      }
    }

    internal void LaunchCloseHandlerOfEachChildForm()
    {
      foreach (KeyValuePair<string, TJChildForm> entry in DictionaryChildForms)
        entry.Value.LaunchEndHandler();
    }
  }
}