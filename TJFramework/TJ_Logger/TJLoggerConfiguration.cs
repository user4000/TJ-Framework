using System;
using Serilog;

namespace TJFramework.Logger
{
  using TJFramework;
  public class TJLoggerConfigurator
  {
    private static Serilog.LoggerConfiguration serilogConfig = null;
    public bool LoggerIsActive { get; private set; } = false;
    internal TJLoggerConfigurator()  {  } /* Hidden Constructor */

    public string Directory { get; set; } = TJLoggerDefaultConfiguration.directory;
    public string Prefix { get; set; } = TJLoggerDefaultConfiguration.prefix;
    public string OutputTemplate { get; set; } = TJLoggerDefaultConfiguration.outputTemplate;
    public int RetainedFileCountLimit { get; set; } = TJLoggerDefaultConfiguration.retainedFileCountLimit;
    public int FileSizeLimitBytes { get; set; } = TJLoggerDefaultConfiguration.fileSizeLimitBytes;
    public bool RollOnFileSizeLimit { get; set; } = TJLoggerDefaultConfiguration.rollOnFileSizeLimit;
    public bool Buffered { get; set; } = TJLoggerDefaultConfiguration.buffered;
    public bool Shared { get; set; } = TJLoggerDefaultConfiguration.shared;
    public TimeSpan FlushToDiskInterval { get; set; } = TJLoggerDefaultConfiguration.flushToDiskInterval;

    public void EnableLogger(bool Enable) => LoggerIsActive = Enable;

    public void Create()
    {
      TJLoggerConfigurator Config = this;
      if (serilogConfig == null)
      {
        string dateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss"); // Time point of logger creation //
        string fileName = $"{Config.Directory}/{Config.Prefix}_{dateTime}.txt";

        serilogConfig =
           new Serilog.LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File
                        (
                          fileName,
                          outputTemplate: Config.OutputTemplate,
                          retainedFileCountLimit: Config.RetainedFileCountLimit,
                          fileSizeLimitBytes: Config.FileSizeLimitBytes,
                          rollOnFileSizeLimit: Config.RollOnFileSizeLimit,
                          buffered: Config.Buffered,
                          shared: Config.Shared,
                          flushToDiskInterval: Config.FlushToDiskInterval,
                          rollingInterval: Serilog.RollingInterval.Infinite
                        );

        Serilog.Log.Logger = serilogConfig.CreateLogger();

        Config.EnableLogger(true);

        ILoggerSubsystem logger = new TJLogger();

        Manager.InitLoggerSubsystem(logger);
      }
    }
  }
}
