using System;
using System.Drawing;
using Newtonsoft.Json;
using System.Windows.Forms;
using Telerik.WinControls;
using TJFramework.Standard;

namespace TJFramework
{
  [Serializable]
  public class TJMessage
  {
    internal string Text { get; set; } = string.Empty;
    internal string Header { get; set; } = string.Empty;
    internal MsgType MessageType { get; set; } = MsgType.Debug;
    internal MsgPos AlertPosition { get; set; } = MsgPos.BottomRight;

    internal bool FlagTable { get; set; } = true;
    internal bool FlagAlert { get; set; } = true;
    internal bool FlagFile { get; set; } = false;
    internal bool FlagPinned { get; set; } = false;
    internal bool FlagShowPinButton { get; set; } = false;
    internal bool FlagCloseOnClick { get; set; } = false;
    internal bool FlagIcon { get; set; } = true;
    internal bool FlagRemovePreviousAlerts { get; set; } = false;
    internal int AutoCloseDelay { get; set; } = 0;

    [JsonIgnore]
    internal Control AlertControl { get; set; } = null;

    [JsonIgnore]
    internal RadElement AlertRadElement { get; set; } = null;


    internal Size AlertSize { get; set; } = TJStandard.ZeroSize ;

    internal Point AlertOffset { get; set; } = TJStandard.ZeroPoint;

    public TJMessage Position(MsgPos position)
    {
      AlertPosition = position; return this;
    }

    public TJMessage Pos(MsgPos position) => Position(position);

    public TJMessage Size(Size size)
    {
      AlertSize = size; return this;
    }

    public TJMessage Size(int X, int Y) => Size(new Size(X, Y));

    public TJMessage Offset(Point offset)
    {
      AlertOffset = offset; return this;
    }

    public TJMessage Offset(int X, int Y) => Offset(new Point(X, Y));

    public TJMessage Control(Control control)
    {
      AlertControl = control; return this;
    }

    public TJMessage Wire(Control control) => Control(control);

    public TJMessage Delay(int seconds)
    {
      AutoCloseDelay = seconds; return this;
    }

    public TJMessage Table(bool SaveToTable)
    {
      FlagTable = SaveToTable; return this;
    }

    public TJMessage RemovePrevious(bool ImmediatelyClosePreviousAlerts = true)
    {
      FlagRemovePreviousAlerts = ImmediatelyClosePreviousAlerts; return this;
    }

    public TJMessage Alert(bool ShowAlert)
    {
      FlagAlert = ShowAlert; return this;
    }

    public TJMessage File(bool SaveToLogFile)
    {
      FlagFile = SaveToLogFile; return this;
    }

    public TJMessage Pin()
    {
      FlagPinned = true; FlagShowPinButton = true; return this;
    }

    public TJMessage PinButton()
    {
      FlagShowPinButton = true; return this;
    }

    public TJMessage NoIcon()
    {
      FlagIcon = false; return this;
    }

    public TJMessage CloseOnClick()
    {
      FlagCloseOnClick = true; return this;
    }

    public TJMessage ToFile() => File(true);

    public TJMessage NoAlert() => Alert(false);

    public TJMessage NoTable() => Table(false);

    public void Create() => TJFrameworkManager.Ms.Create(this);

    public void Debug(int delaySeconds = 0)
    {
      MessageType = MsgType.Debug;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }

    public void Info(int delaySeconds = 0)
    {
      MessageType = MsgType.Info;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }

    public void Ok(int delaySeconds = 0)
    {
      MessageType = MsgType.Ok;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }

    public void Fail(int delaySeconds = 0)
    {
      MessageType = MsgType.Fail;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }

    public void Warning(int delaySeconds = 0)
    {
      MessageType = MsgType.Warning;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }

    public void Error(int delaySeconds = 0)
    {
      MessageType = MsgType.Error;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }
  }
}