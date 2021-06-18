using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Threading;
using TJFramework.Standard;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TJFramework.Extensions;
using static TJFramework.Logger.Manager;
using static TJFramework.TJFrameworkManager;

namespace TJFramework.Form
{
  internal class AxLog : TJGridWithDataTable
  {
    internal int CountRow { get; private set; } = 0;

    internal int MaxCountRow { get; } = 10000;

    internal int MaxHeaderLength { get; } = 5000;

    internal int MaxMessageLength { get; } = 10000;

    private int DeltaWidth { get; } = -20;

    private int CoTextMessageMinimumWidth { get; } = 100;

    private int MinRowHeight { get; } = 25;

    private int MaxRowHeight { get; } = 100;

    internal FxLog FormLog { get; private set; } = null;

    internal AxLog(FxLog form) => FormLog = form;

    internal GridViewTextBoxColumn CoIdMessage { get; set; } = null;

    internal GridViewTextBoxColumn CoDateMessage { get; set; } = null;

    internal GridViewTextBoxColumn CoTypeMessage { get; set; } = null;

    internal GridViewTextBoxColumn CoTextMessage { get; set; } = null;

    internal GridViewTextBoxColumn CoTypePresentation { get; set; } = null;

    internal GridViewTextBoxColumn CoHeaderMessage { get; set; } = null;

    internal string[] ArrayMessageType { get; set; } = new string[6];

    internal Font FontWingdingsRegular { get; set; } = new Font("Wingdings", 16);

    internal Font FontWebdingsRegular { get; set; } = new Font("Webdings", 14);

    internal Font FontWebdingsBold { get; set; } = new Font("Webdings", 14, FontStyle.Bold);

    internal Random CxRnd { get; } = new Random();

    internal string CvHeaderMessage { get => Grid.ZzGetStringValueByFieldName(nameof(MxMessageLog.HeaderMessage)); }

    internal string CvTextMessage { get => Grid.ZzGetStringValueByFieldName(nameof(MxMessageLog.TextMessage)); }

    internal void InitMessageSubsystem() => Ms.InitMessageSubsystem(MessageHandler);





    // https://stackoverflow.com/questions/29411961/c-sharp-and-thread-safety-of-a-bool/49233660 //
    // default is false, set 1 for true //
    private int _threadSafeBoolValueAllowAddNewRows = 1;

    public bool FlagAllowAddNewRowsToTheTable // Флаг показывает можно ли добавлять новые строки в таблицу //
    {
      get { return (Interlocked.CompareExchange(ref _threadSafeBoolValueAllowAddNewRows, 1, 1) == 1); }
      set
      {
        if (value) Interlocked.CompareExchange(ref _threadSafeBoolValueAllowAddNewRows, 1, 0);
        else Interlocked.CompareExchange(ref _threadSafeBoolValueAllowAddNewRows, 0, 1);
      }
    }







    internal void EventFormIsGoingToBeClosed()
    {
      FlagAllowAddNewRowsToTheTable = false;
      Ms.TurnOffMessageSubsystem();
    }

    internal void EventStartWork()
    {
      InitArrayMessageType();
      AddConditionalFormatting();
      SetEvents();
    }

    internal void SetEvents()
    {
      Grid.SizeChanged += new EventHandler(EventGridSizeChanged);
      Grid.DoubleClick += new EventHandler(EventGridDoubleClick);
      Grid.SelectionChanged += new EventHandler(EventGridSelectionChanged);
      //Grid.RowHeightChanging += EventGridRowHeightChanging;
      //Grid.CellFormatting += new CellFormattingEventHandler(EventCellFormatting);
      //Grid.RowFormatting += new RowFormattingEventHandler(EventRowFormatting);
    }

    internal void EventUserVisitedThisPage()
    {
      if (Grid.SelectedRows.Count > 0)
        try
        {
          Grid.SelectedRows[0].EnsureVisible();
          Grid.TableElement.ScrollToRow(Grid.SelectedRows[0]);
          AdjustMessageTextColumnWidth();
        }
        catch
        {

        };
    }

    internal void EventCopyMessageToDetailMessagePanel()
    {
      FormLog.TxtHeader.Text = CvHeaderMessage;
      FormLog.TxtMessage.Text = CvTextMessage;
    }

    internal void EventCopyMessageToClipboard(object sender, EventArgs e)
    {
      Service.AlertService.RemoveAllAlerts();

      if (Table.Rows.Count < 1)
      {
        Ms.ShortMessage(MsgType.Fail, "No any text to copy", 250, FormLog.BtnCopyToClipboard, MsgPos.Unknown, 2).NoTable().Create();
        return;
      }

      try
      {
        Clipboard.SetText(CvHeaderMessage + "\n " + CvTextMessage + "\n");
        Ms.ShortMessage(MsgType.Debug, "Text is copied to clipboard", 250, FormLog.BtnCopyToClipboard, MsgPos.Unknown, 2).NoTable().Create();
      }
      catch
      {

      }
    }

    private void EventGridSelectionChanged(object sender, EventArgs e)
    {
      if (FormLog.PnMessage.Visible) EventCopyMessageToDetailMessagePanel();
    }

    private int SumColumnWidth()
    { // Sum of width of all columns except TextMessage Column //
      return CoIdMessage.Width + CoDateMessage.Width + CoTypePresentation.Width + CoHeaderMessage.Width;
    }

    private void EventGridSizeChanged(object sender, EventArgs e) => AdjustMessageTextColumnWidth();

    private void AdjustMessageTextColumnWidth()
    {
      CoTextMessage.Width = Math.Max(CoTextMessageMinimumWidth, DeltaWidth + Grid.Size.Width - SumColumnWidth());
    }

    internal void InitArrayMessageType()
    {
      ArrayMessageType[0] = TJStandard.MessageType1;
      ArrayMessageType[1] = TJStandard.MessageType2;
      ArrayMessageType[2] = TJStandard.MessageType3;
      ArrayMessageType[3] = TJStandard.MessageType4;
      ArrayMessageType[4] = TJStandard.MessageType5;
      ArrayMessageType[5] = TJStandard.MessageType6;
    }

    internal void AddConditionalFormatting()
    {
      ConditionalFormattingObject format = new ConditionalFormattingObject("Debug", ConditionTypes.Equal, TJStandard.MessageType1.ToString(), "", false);
      format.CellForeColor = Color.Black;
      format.CellFont = FontWingdingsRegular;
      CoTypePresentation.ConditionalFormattingObjectList.Add(format);

      format = new ConditionalFormattingObject("Info", ConditionTypes.Equal, TJStandard.MessageType2.ToString(), "", false);
      format.CellForeColor = Color.DeepSkyBlue;
      format.CellFont = FontWebdingsBold;
      CoTypePresentation.ConditionalFormattingObjectList.Add(format);

      format = new ConditionalFormattingObject("Ok", ConditionTypes.Equal, TJStandard.MessageType3.ToString(), "", false);
      format.CellForeColor = Color.Green;
      format.CellFont = FontWebdingsBold;
      format.ApplyToRow = false;
      CoTypePresentation.ConditionalFormattingObjectList.Add(format);

      format = new ConditionalFormattingObject("Failure1", ConditionTypes.Equal, TJStandard.MessageType4.ToString(), "", false);
      format.CellBackColor = Color.Yellow;
      format.CellForeColor = Color.Brown;
      format.CellFont = FontWebdingsRegular;
      format.ApplyToRow = false;
      CoTypePresentation.ConditionalFormattingObjectList.Add(format);

      format = new ConditionalFormattingObject("Failure2", ConditionTypes.Equal, TJStandard.MessageType4.ToString(), "", true);
      format.RowForeColor = Color.Navy;
      CoTypePresentation.ConditionalFormattingObjectList.Add(format);

      format = new ConditionalFormattingObject("Warning1", ConditionTypes.Equal, TJStandard.MessageType5.ToString(), "", false);
      format.CellBackColor = Color.Yellow;
      format.CellForeColor = Color.Magenta;
      format.CellFont = FontWebdingsBold;
      format.ApplyToRow = false;
      CoTypePresentation.ConditionalFormattingObjectList.Add(format);

      format = new ConditionalFormattingObject("Warning2", ConditionTypes.Equal, TJStandard.MessageType5.ToString(), "", true);
      format.RowForeColor = Color.Brown;
      CoTypePresentation.ConditionalFormattingObjectList.Add(format);

      format = new ConditionalFormattingObject("Error1", ConditionTypes.Equal, TJStandard.MessageType6.ToString(), "", false);
      format.CellBackColor = Color.LightPink;
      format.CellForeColor = Color.Red;
      format.CellFont = FontWebdingsRegular;
      format.ApplyToRow = false;
      CoTypePresentation.ConditionalFormattingObjectList.Add(format);

      format = new ConditionalFormattingObject("Error2", ConditionTypes.Equal, TJStandard.MessageType6.ToString(), "", true);
      format.RowForeColor = Color.DeepPink;
      CoTypePresentation.ConditionalFormattingObjectList.Add(format);
    }

    internal void AddRandomMessages(int messages)
    {
      for (int i = 0; i < messages; i++) TestAddOneRowToTable();
    }

    internal override void SetDataViewControlProperties()
    {
      CreateColumns();
      Grid.ReadOnly = true;
      Grid.AllowEditRow = false;
      Grid.AllowRowResize = false;
      Grid.MultiSelect = false;
      Grid.AllowSearchRow = false;
      Grid.EnableFiltering = true;
      Grid.EnableGrouping = false;
      Grid.AllowColumnResize = true;
      Grid.ShowColumnHeaders = true;
      Grid.ShowRowHeaderColumn = false;
      Grid.AllowMultiColumnSorting = false;
      Grid.EnableSorting = false;
      Grid.EnableCustomSorting = false;
      Grid.AllowColumnHeaderContextMenu = false;
      Grid.ShowFilteringRow = false;
      Grid.AutoScroll = true;
      Grid.SelectionMode = GridViewSelectionMode.FullRowSelect;
      Grid.TableElement.RowHeight = MinRowHeight;
      Grid.TableElement.TableHeaderHeight = MinRowHeight;
      Grid.MasterView.TableSearchRow.ShowCloseButton = false;
    }

    private void EventGridDoubleClick(object sender, EventArgs e)
    {
      //Grid.AutoSizeRows = !Grid.AutoSizeRows;
      Grid.TableElement.RowHeight = (Grid.TableElement.RowHeight < MaxRowHeight) ? MaxRowHeight : MinRowHeight;
      CoTextMessage.WrapText = Grid.TableElement.RowHeight != MinRowHeight;
      CoHeaderMessage.WrapText = CoTextMessage.WrapText;
    }

    private void EventGridRowHeightChanging(object sender, RowHeightChangingEventArgs e)
    {
      if ((e.NewHeight < MinRowHeight) || (e.NewHeight > MaxRowHeight)) e.Cancel = true;
    }

    internal void CreateColumns()
    {
      CoIdMessage = AddColumn<GridViewTextBoxColumn>(nameof(MxMessageLog.IdMessage), "", true, typeof(int), 50);
      CoDateMessage = AddColumn<GridViewTextBoxColumn>(nameof(MxMessageLog.DateMessage), "", true, typeof(string), 140);
      CoTypePresentation = AddColumn<GridViewTextBoxColumn>(nameof(MxMessageLog.TypePresentation), "", true, typeof(string), 25);
      CoHeaderMessage = AddColumn<GridViewTextBoxColumn>(nameof(MxMessageLog.HeaderMessage), "", true, typeof(string), 300);
      CoTextMessage = AddColumn<GridViewTextBoxColumn>(nameof(MxMessageLog.TextMessage), "", true, typeof(string), 450);
      CoTypeMessage = AddColumn<GridViewTextBoxColumn>(nameof(MxMessageLog.TypeMessage), "", true, typeof(byte), 0);

      CoTypeMessage.IsVisible = false;

      CoIdMessage.ZzPin();
      CoIdMessage.AllowResize = false;
      CoIdMessage.AllowFiltering = false;

      CoTypePresentation.AllowResize = false;
      CoTypePresentation.TextAlignment = ContentAlignment.MiddleCenter;
      CoTypePresentation.AllowFiltering = false;

      CoTextMessage.WrapText = false;
      CoHeaderMessage.WrapText = false;
      CoHeaderMessage.MaxWidth = 800;

      Table.Columns.Add(nameof(MxMessageLog.IdMessage), typeof(int)).AutoIncrement = true;
      Table.Columns[0].AutoIncrementSeed = 1;
      Table.Columns.Add(nameof(MxMessageLog.DateMessage), typeof(string));
      Table.Columns.Add(nameof(MxMessageLog.TypePresentation), typeof(string));
      Table.Columns.Add(nameof(MxMessageLog.HeaderMessage), typeof(string));
      Table.Columns.Add(nameof(MxMessageLog.TextMessage), typeof(string));
      Table.Columns.Add(nameof(MxMessageLog.TypeMessage), typeof(byte));
    }

    internal void EventTestButtonClick(object sender, EventArgs e)
    {
      Grid.BeginUpdate();
      TestAddManyRowsToTable();
      Grid.EndUpdate();
      SelectLastRow();
    }

    internal void AddOneRow(byte NxByte, string StHeader, string StText)
    {
      if (FlagAllowAddNewRowsToTheTable == false) return;

      if (NxByte > 5) NxByte = (byte)(NxByte % 6);

      DataRow row = Table.NewRow();
      row[1] = TJConvert.Time;
      row[2] = ArrayMessageType[NxByte];
      row[3] = StHeader.Left(MaxHeaderLength);
      row[4] = StText.Left(MaxMessageLength);
      row[5] = NxByte;
      Table.Rows.Add(row);

      CountRow++;
      DeleteOldRows();
      if (FormLog.PanelMessageIsVisible) EventCopyMessageToDetailMessagePanel();
    }

    internal void SelectLastRow()
    {
      try
      {
        Grid.TableElement.ScrollToRow(Grid.Rows.Last());
        Grid.CurrentRow = Grid.Rows.Last();
      }
      catch
      {

      }
    }

    private void DeleteAllRowsInnerMethod()
    {
      FlagAllowAddNewRowsToTheTable = false;

      DataRow[] rows;

      try
      {
        rows = Table.Select();
        Grid.BeginUpdate();
        foreach (DataRow row in rows) row.Delete();
        Grid.EndUpdate();
      }
      catch
      {

      }

      FlagAllowAddNewRowsToTheTable = true;
    }

    internal void DeleteAllRows()
    {
      if (Table.Rows.Count > 0)
      {
        DeleteAllRowsInnerMethod();
      }
    }

    private void DeleteOldRowsInnerMethod()
    {
      FlagAllowAddNewRowsToTheTable = false;
      DataRow[] rows;
      try
      {
        rows = Table.Select($"{nameof(MxMessageLog.IdMessage)} < {CountRow - MaxCountRow}");
        Grid.BeginUpdate();
        foreach (DataRow row in rows) row.Delete();
        Grid.EndUpdate();
        SelectLastRow();
      }
      catch
      {

      }
      FlagAllowAddNewRowsToTheTable = true;
    }

    internal void DeleteOldRows()
    {
      if ((CountRow % 1000 == 0) && (Table.Rows.Count > MaxCountRow))
      {
        DeleteOldRowsInnerMethod();
      }
    }

    internal void TestAddOneRowToTable()
    {
      AddOneRow((byte)CxRnd.Next(0, 6),
        TJString.RandomPhrase(CxRnd.Next(1, 22)), TJString.RandomPhrase(CxRnd.Next(1, 175)));
    }

    internal void TestAddManyRowsToTable()
    {
      for (int i = 1; i < 1002; i++) AddOneRow((byte)CxRnd.Next(0, 6), $"{CountRow}", "xa xa");
    }

    internal void MessageHandler(TJMessage Message)
    {
      if (Message.FlagTable)
      {
        AddOneRowThreadSafe(Message);
      }

      if (Message.FlagFile)
      {
        Log.Save(Message.MessageType, Message.Header, Message.Text);
      }

      if (Message.FlagAlert)
      {
        ShowAlertThreadSafe(Message);
      }
    }

    private void AddOneRowThreadSafe(TJMessage Message)
    {
      if (FormLog.InvokeRequired) // Method is called from non-UI-thread //
      {
        FormLog.Invoke
        (
          (Action)delegate ()
          {
            AddOneRow((byte)Message.MessageType, Message.Header, Message.Text);
          }
        );
      }
      else // Method is called from UI-thread //
      {
        AddOneRow((byte)Message.MessageType, Message.Header, Message.Text);
      }
    }

    private void ShowAlertThreadSafe(TJMessage Message)
    {
      if (FormLog.InvokeRequired) // Method is called from non-UI-thread //
      {
        FormLog.Invoke
        (
          (Action)delegate ()
          {
            Service.AlertService.ShowAlert(Message);
          }
        );
      }
      else // Method is called from UI-thread //
      {
        Service.AlertService.ShowAlert(Message);
      }
    }
  }
}

/*
    internal void AddOneRow(byte NxByte, string StHeader, string StText)
    {
      if (NxByte > 5) NxByte = (byte)(NxByte % 6);

      DataRow row = Table.NewRow();
      row[1] = TJConvert.Time;
      row[2] = ArrayMessageType[NxByte];
      row[3] = StHeader;
      row[4] = StText;
      row[5] = NxByte;
      Table.Rows.Add(row);
   
      //GridViewRowInfo row = Grid.Rows.AddNew();
      //row.Cells[1].Value = TJConvert.Time;
      //row.Cells[2].Value = ArrayMessageType[NxByte];
      //row.Cells[3].Value = StHeader;
      //row.Cells[4].Value = StText;
      //row.Cells[5].Value = NxByte;
      
      CountRow++;
      DeleteOldRows();
      if (FormLog.PanelMessageIsVisible) EventCopyMessageToDetailMessagePanel();

      //Grid.BeginUpdate();
      //SelectLastRow();
      //Grid.EndUpdate();
    }
*/
