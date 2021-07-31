using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Threading.Tasks;

namespace TJFramework.Form
{
  public partial class FxLog : RadForm, IEventStartWork, IEventEndWork
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

      SetEvents();
    }

    public void SetEvents()
    {
      BtnShowDetailMessage.Click += new EventHandler(EventButtonShowDetailMessageClick);
      BtnTest.Click += new EventHandler(CxLog.EventTestButtonClick);
      BtnCopyToClipboard.Click += new EventHandler(CxLog.EventCopyMessageToClipboard);
      BtnFilter.Click += new EventHandler(EventButtonFilterClick);
      BtnSearchField.Click += new EventHandler(EventButtonClickSearchField);
      BtnClearTable.Click += new EventHandler(EventClearTable);
    }

    private async void EventClearTable(object sender, EventArgs e)
    {
      BtnClearTable.Enabled = false;
      CxLog.DeleteAllRows();
      await Task.Delay(250);
      BtnClearTable.Enabled = true;
    }

    public void EventUserVisitedThisPage()
    {
      if (PanelMessageIsVisible) EventButtonShowDetailMessageClick();
      CxLog.EventUserVisitedThisPage();
    }

    private async void EventButtonClickSearchField(object sender, EventArgs e)
    {
      BtnSearchField.Enabled = false;
      GxLog.AllowSearchRow = !GxLog.AllowSearchRow;
      await Task.Delay(250);
      BtnSearchField.Enabled = true;
    }

    internal async void EventButtonFilterClick(object sender, EventArgs e)
    {
      BtnFilter.Enabled = false;
      GxLog.ShowFilteringRow = !GxLog.ShowFilteringRow;
      await Task.Delay(250);
      BtnFilter.Enabled = true;
    }

    internal async void EventButtonShowDetailMessageClick(object sender, EventArgs e)
    {
      BtnShowDetailMessage.Enabled = false;
      EventButtonShowDetailMessageClick();
      await Task.Delay(100);
      BtnShowDetailMessage.Enabled = true;
    }

    internal void EventButtonShowDetailMessageClick()
    {
      PanelMessageIsVisible = !PnMessage.Visible;
      PnMessage.Visible = PanelMessageIsVisible;
      if (PanelMessageIsVisible) CxLog.EventCopyMessageToDetailMessagePanel();
      try { CxLog.Grid.CurrentRow.EnsureVisible(); } catch { };
    }

    public void EventEndWork()
    {
      CxLog.EventFormIsGoingToBeClosed();
    }
  }
}