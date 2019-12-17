using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace TJFramework.Form
{
  public partial class FxLog : RadForm, IEventStartWork
  {
    internal AxLog CxLog { get; private set; }

    internal bool PanelMessageIsVisible { get; private set; } = false;

    public FxLog()
    {
      InitializeComponent();
    }

    public void EventStartWork()
    {
      CxLog = new AxLog(this);
      CxLog.InitializeGrid(GxLog);
      CxLog.EventStartWork();
      CxLog.InitMessageSubsystem(); /* Very important */

      PnMessage.Visible = PanelMessageIsVisible;
      GxLog.Dock = DockStyle.Fill;
      BtnShowDetailMessage.Click += EventButtonShowDetailMessageClick;
      BtnTest.Click += CxLog.EventTestButtonClick;
      BtnCopyToClipboard.Click += CxLog.EventCopyMessageToClipboard;
      BtnFilter.Click += EventButtonFilterClick;
      BtnSearchField.Click += EventButtonClickSearchField;
    }

    public void EventUserVisitedThisPage()
    {
      if (PanelMessageIsVisible) EventButtonShowDetailMessageClick();
      CxLog.EventUserVisitedThisPage();
    }

    private void EventButtonClickSearchField(object sender, EventArgs e)
    {
      GxLog.AllowSearchRow = !GxLog.AllowSearchRow;
    }

    internal void EventButtonFilterClick(object sender, EventArgs e)
    {
      GxLog.ShowFilteringRow = !GxLog.ShowFilteringRow;
    }

    internal void EventButtonShowDetailMessageClick(object sender, EventArgs e)
    {
      EventButtonShowDetailMessageClick();
    }

    internal void EventButtonShowDetailMessageClick()
    {
      PanelMessageIsVisible = !PnMessage.Visible;
      PnMessage.Visible = PanelMessageIsVisible;
      if (PanelMessageIsVisible) CxLog.EventCopyMessageToDetailMessagePanel();
      try { CxLog.Grid.CurrentRow.EnsureVisible(); } catch { };
    }
  }
}
