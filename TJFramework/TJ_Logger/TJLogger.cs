using System;
using Serilog;

namespace TJFramework.Logger
{
  internal class TJLogger : ILoggerSubsystem
  {
    private bool IsActive() => TJFrameworkManager.Logger.LoggerIsActive;  

    public void Save(MsgType type, string header, string message)
    {
      if (IsActive() == false) return;
      string HeaderAndMessage = header + " " + message;
      switch (type)
      {
        case MsgType.Debug: Log.Debug(HeaderAndMessage); break;
        case MsgType.Info: Log.Information(HeaderAndMessage); break;
        case MsgType.Ok: Log.Information(HeaderAndMessage); break;
        case MsgType.Fail: Log.Warning(HeaderAndMessage); break;
        case MsgType.Warning: Log.Error(HeaderAndMessage); break;
        case MsgType.Error: Log.Fatal(HeaderAndMessage); break;
        default: Log.Debug(HeaderAndMessage); break;
      }
    }

    public void Save(string header, string message) => Save(MsgType.Debug, header, message);

    public void Save(string message) => Save(MsgType.Debug, string.Empty, message);

    public void Save(Exception exception, string message, MsgType type = MsgType.Warning)
    {
      if (IsActive() == false) return;
      switch (type)
      {
        case MsgType.Debug: Log.Debug(exception, message); break;
        case MsgType.Info: Log.Information(exception, message); break;
        case MsgType.Ok: Log.Information(exception, message); break;
        case MsgType.Fail: Log.Warning(exception, message); break;
        case MsgType.Warning: Log.Error(exception, message); break;
        case MsgType.Error: Log.Fatal(exception, message); break;
        default: Log.Error(exception, message); break;
      }
    }
  }
}