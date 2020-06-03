using System;
using System.Windows.Forms;

namespace TJFramework
{
  public interface IMessageSubsystem
  {
    TJMessage Message(string header, string message);

    TJMessage Message(string header, string message, Control control);

    TJMessage Message(string header, string message, MsgPos position);

    TJMessage Message(string header, string message, MsgType type);

    TJMessage Message(MsgType type, string header, string message, Control control = null, MsgPos position = MsgPos.Unknown, int delay = 0);

    TJMessage ShortMessage(MsgType type, string message, int Width, Control control = null, MsgPos position = MsgPos.Unknown, int delay = 0);

    TJMessage ShortMessage(string message, int Width, Control control = null, MsgPos position = MsgPos.Unknown, int delay = 0);

    TJMessage Error(string header, Exception ex);
  }
}
