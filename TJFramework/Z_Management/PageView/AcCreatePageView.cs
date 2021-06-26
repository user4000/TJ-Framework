using System.Drawing;
using TJFramework.Form;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Collections.Generic;

namespace TJFramework
{
  public partial class TJPageView
  {
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
  }
}
