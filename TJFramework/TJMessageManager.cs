using System;
using System.Drawing;
using System.Windows.Forms;
using static TJFramework.Logger.Manager;

namespace TJFramework
{
  public class TJMessageManager : IMessageSubsystem
  {
    public int ShortMessageAlertHeight { get; } = 32;

    public TJMessage Message(string header, string message) => new TJMessage { Header = header, Text = message };

    public TJMessage Message(string header, string message, Control control) => new TJMessage { Header = header, Text = message, AlertControl = control };

    public TJMessage Message(string header, string message, MsgPos position) => new TJMessage { Header = header, Text = message, AlertPosition = position };

    public TJMessage Message(string header, string message, MsgType type) => new TJMessage { Header = header, Text = message, MessageType = type };

    public TJMessage Message(MsgType type, string header, string message, Control control = null, MsgPos position = MsgPos.Unknown, int delay = 0) => new TJMessage { Header = header, Text = message, MessageType = type, AlertControl = control, AlertPosition = position, AutoCloseDelay = delay };

    public TJMessage Error(string header, Exception ex)
    {
      string message =
        "An exception was encountered." +
        "\nType : " + ex.GetType().ToString() +
        "\nData : " + ex.Data +
        "\nInner : " + ex.InnerException +
        "\nMessage : " + ex.Message +
        "\nSource : " + ex.Source +
        "\nStackTrace : " + ex.StackTrace;
      return new TJMessage
      {
        Header = header,
        Text = message,
        MessageType = MsgType.Error,
        FlagFile = true
      };
    }

    public TJMessage ShortMessage(MsgType type, string ShortMessage, int Width, Control control = null, MsgPos position = MsgPos.Unknown, int delay = 0)
      => 
      new TJMessage
      {
        Header = ShortMessage,
        MessageType = type,
        AlertControl = control,
        AlertPosition = position,
        AutoCloseDelay = delay,
        AlertSize = new Size(Width, ShortMessageAlertHeight),
        FlagIcon = false
      };

    public Action<TJMessage> Create { get; private set; } = DoNothing;

    private static void DoNothing(TJMessage Message)
    {

    }

    internal void InitMessageSubsystem(Action<TJMessage> MessageHandlerMethod)
    {
      if (Create == DoNothing) Create = MessageHandlerMethod;
    }
  }
}
