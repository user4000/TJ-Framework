using System;

namespace TJFramework.Logger
{
  internal static class TJLoggerDefaultConfiguration
  {
    public static string directory = "log";
    public static string prefix = "log";
    public static string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}";
    public static int retainedFileCountLimit = 1000;
    public static int fileSizeLimitBytes = 1000000;
    public static bool rollOnFileSizeLimit = true;
    public static bool buffered = false;
    public static bool shared = false;
    public static TimeSpan flushToDiskInterval = TimeSpan.FromMinutes(1);
  }
}
