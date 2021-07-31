using System;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TJFramework;
using TJFramework.FrameworkSettings;

namespace TJFrameworkExample
{
  static class Program
  {
    const string ApplicationUniqueName = "TJFrameworkExample 2020-03-21";
    private static Mutex AxMutex = null;

    public static MySettings ApplicationSettings { get => TJFrameworkManager.ApplicationSettings<MySettings>(); } // User custom settings in Property Grid //

    public static TJStandardFrameworkSettings FrameworkSettings { get; } = TJFrameworkManager.FrameworkSettings; // Framework embedded settings //

    public static CxManager Manager { get; } = CxManagerFactory.Create();

    private static void TestEventPageChanged(string PageName)
    {
      MessageBox.Show("You have changed a page = " + PageName);
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    { 
      AxMutex = new Mutex(true, ApplicationUniqueName, out bool createdNew);
      if (!createdNew)
      {
        MessageBox.Show("Another instance of the application is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      TJFrameworkManager.Logger.FileSizeLimitBytes = 1000000;
      TJFrameworkManager.Logger.Create(Assembly.GetExecutingAssembly().GetName().Name);

      TJFrameworkManager.Service.CreateApplicationSettings<MySettings>(Assembly.GetExecutingAssembly().GetName().Name);








      TJFrameworkManager.Service.AddForm<FxTestOne>("Это форма номер 1", true, true);

      TJFrameworkManager.Service.AddForm<FxTestTwo>("Тест вторая форма привет вам друзья", false, true);

      TJFrameworkManager.Service.AddForm<FxTestThree>("Number 3", true, false);

      TJFrameworkManager.Service.StartPage<FxTestTwo>();








      TJFrameworkManager.Service.SetMainFormCaption("Привет! Это главная форма 123.");
      //TJFrameworkManager.Service.SetMainPageViewOrientation(StripViewAlignment.Left);

      FrameworkSettings.HeaderFormSettings = "Настройки";
      FrameworkSettings.HeaderFormLog = "Сообщения";
      FrameworkSettings.HeaderFormExit = "Выход";
      //FrameworkSettings.ConfirmExitButtonText = "Подтвердите выход";

      FrameworkSettings.MainFormMinimizeToTray = false;
      FrameworkSettings.VisualEffectOnStart = false;
      FrameworkSettings.VisualEffectOnExit = false;

      //FrameworkSettings.FlagMainPageViewVisibleWhileMainFormIsStarting = false;
      //FrameworkSettings.MainFormDelayMillisecondsBeforeUserFormsAreLoaded = 2000;

      FrameworkSettings.ValueColumnWidthPercent = 60;
      FrameworkSettings.MainPageViewReducePadding = true;
      FrameworkSettings.RememberMainFormLocation = true;
      FrameworkSettings.PageViewFont = new Font("Verdana", 10);

      FrameworkSettings.FontAlertText = new Font("Verdana", 9);
      FrameworkSettings.FontAlertCaption = new Font("Verdana", 9);
      FrameworkSettings.MaxAlertCount = 5;
      FrameworkSettings.LimitNumberOfAlerts = true;
      FrameworkSettings.SecondsAlertAutoClose = 5;

      Action ExampleOfVisualSettingsAndEvents = () =>
      {
        FrameworkSettings.MainFormMargin = 50;
        FrameworkSettings.PageViewItemSize = new Size(200, 30);
        FrameworkSettings.ItemSizeMode = PageViewItemSizeMode.EqualSize;
        FrameworkSettings.PageViewItemSpacing = 50;
        FrameworkSettings.PropertyGridPadding = new Padding(155, 100, 45, 25);

        // Привязка различных событий фреймворка к методам класса CxManager //

        //TJFrameworkManager.Service.EventPageChanged = Manager.EventPageChanged;
        //TJFrameworkManager.Service.EventBeforeMainFormClose = Manager.EventBeforeMainFormClose;
      };


      Func<Task> fnEventBeforeMainFormCloseAsync = async () =>
      {
        await Manager.EventBeforeMainFormCloseAsync();
      };


      TJFrameworkManager.Service.EventBeforeMainFormClose = Manager.EventBeforeMainFormClose;
      TJFrameworkManager.Service.FuncBeforeMainFormClose = fnEventBeforeMainFormCloseAsync;

      TJFrameworkManager.Run();
    }
  }
}