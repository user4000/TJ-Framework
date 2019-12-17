using System.Windows.Forms;
using TJFramework.Form;
using TJFramework.Logger;
using TJFramework.FrameworkSettings;

namespace TJFramework
{
  public class TJFrameworkManager
  {
    public static FxMain MainForm { get; private set; } = null;

    public static TJService Service { get; } = new TJService();

    public static TJPageView Pages { get => Service.MainPageViewManager; }

    public static TJLoggerConfigurator Logger { get; } = new TJLoggerConfigurator();

    public static TJMessageManager Ms { get; } = new TJMessageManager();

    public static T ApplicationSettings<T>() => (T)(object)Service.CurrentApplicationSettings;

    public static TJStandardFrameworkSettings FrameworkSettings { get; } = new TJStandardFrameworkSettings();

    public static void Run() => Application.Run(CreateMainForm());

    public static FxMain CreateMainForm()
    {
      if (MainForm==null)
      {
        MainForm = new FxMain();
        Service.InitMainForm(MainForm);
        Service.SetEventsForMainForm();
      }
      return MainForm;
    }
  }
}

