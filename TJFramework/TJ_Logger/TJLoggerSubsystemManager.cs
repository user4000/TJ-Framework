using System;

namespace TJFramework.Logger
{
  internal class TJEmptyLoggerSubsystem : ILoggerSubsystem
  {
    public void Save(MsgType type, string header, string message)
    {

    }

    public void Save(Exception exception, string message, MsgType type = MsgType.Error)
    {

    }

    public void Save(string message)
    {
      
    }

    public void Save(string header, string message)
    {
      
    }
  }

  public static class Manager
  {
    public static ILoggerSubsystem Log = new TJEmptyLoggerSubsystem();

    internal static void InitLoggerSubsystem(ILoggerSubsystem LoggerSubsystem) => Log = LoggerSubsystem;
  }
}