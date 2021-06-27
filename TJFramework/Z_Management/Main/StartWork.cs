using System;
using System.Threading;
using TJFramework.Form;
using TJFramework.Logger;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using TJFramework.FrameworkSettings;
using System.Text.RegularExpressions;

namespace TJFramework
{
  public partial class TJFrameworkManager
  {
    private static bool FlagMainFormIsOnTheScreen { get; set; } = false;

    public static void Run() // Главная точка входа - запуск программы начинается с этого метода //
    {
      FxMain mainForm = CreateMainForm();
      ApplicationContext context = new ApplicationContext(mainForm);
      Application.Run(context);
    }

    private static FxMain CreateMainForm()
    {
      if (MainForm != null) // Данный метод должен быть вызван ровно 1 раз //
      {
        throw new ApplicationException("Method << CreateMainForm() >> has been called more than one time!");
      }

      /* =========================================================================================================================== */
      MainForm = new FxMain();
      MainForm.Visible = false;
      MainForm.Text = string.Empty;
      //MainForm.Load += new EventHandler(EventFormLoad);
      MainForm.Shown += new EventHandler(EventMainFormShown);

      if (FrameworkSettings.VisualEffectOnStart)
      {
        MainForm.Opacity = 0;
      }








      // Если пользователь хочет применить тему приложения, то сделаем это по части имени темы //
      if (string.IsNullOrWhiteSpace(FrameworkSettings.ThemeName) == false)
        Service.SrvTheme.SetApplicationAppearance(FrameworkSettings.ThemeName, null);


      if (FrameworkSettings.FlagMainPageViewVisibleWhileMainFormIsStarting == false)
        MainForm.MainPageView.Visible = false;


      Service.InitMainForm(MainForm);
      Service.SetEventsForMainForm();

      Service.CreateFormSettings();
      Service.SetMainFormMinimumSize();
      Service.SetMainFormSize();
      TJFrameworkManager.FrameworkSettings.RestoreMainFormLocationAndSize();
      Service.CreateMainPageView();

      MainForm.Text = Service.MainFormCaption;
      MainForm.MyNotifyIcon.Text = Service.MainFormCaption;
      MainForm.Icon = MainForm.MyNotifyIcon.Icon;




      // Два нижеследующих трудоёмких метода мы запустим через таймер позже //
      //---------------Service.PrepareToWorkStep1();
      //---------------Service.PrepareToWorkStep2();



      /* =========================================================================================================================== */

      return MainForm;
    }

    private static void EventFormLoad(object sender, EventArgs e)
    {

    }


    private static void MainFormRefresh()
    {
      MainForm.Refresh();
      if (MainForm.MainPageView.Visible) MainForm.MainPageView.Refresh();
    }

    private static async void EventMainFormShown(object sender, EventArgs e)
    {
      MainFormRefresh();
      MainForm.Shown -= EventMainFormShown;

      if (FrameworkSettings.VisualEffectOnStart)
      {
        MainForm.Visible = true;
        Service.VisualEffectFadeIn();
      }

      /*
      BackgroundWorker worker = new BackgroundWorker();
      worker.DoWork += new DoWorkEventHandler(EventBackgroundWorker);
      worker.RunWorkerAsync();

      FlagMainFormIsOnTheScreen = true;
      */


      int delayMs = FrameworkSettings.MainFormDelayMillisecondsBeforeUserFormsAreLoaded;
      if ((delayMs >= 10) && (delayMs <= 60000))
      {
        await Task.Delay(delayMs);
      }

      MainFormRefresh();

      Service.PrepareToWorkStep1();

      MainFormRefresh();

      Service.PrepareToWorkStep2();

      MainFormRefresh();

      //EventStartBackground();
    }

    private static void EventBackgroundWorker(object sender, DoWorkEventArgs e)
    {
      //Service.PrepareToWorkStep1();
      //Service.PrepareToWorkStep2();
      //EventStartBackground();
    }

    private static void TimerStart()
    {
      TmStart.Interval = 100;
      TmStart.Tick += new EventHandler(EventTimerTickStartWork);
      TmStart.Start();
    }

    private static void EventStartBackground()
    {
      MainForm.BeginInvoke((Action)delegate { // https://stackoverflow.com/questions/4665539/new-form-on-a-different-thread //

        // Некоторые формы довольно много времени занимают при создании //
        // Поэтому их создание вынесено в отдельный метод, выполняющийся на заднем фоне основного потока //

        //TimerStart();

        //Service.PrepareToWorkStep1();
        //Service.PrepareToWorkStep2();
      });
    }

    private static void EventTimerTickStartWork(object sender, EventArgs e)
    {
      // Все трудоёмкие операции выполняем через таймер //
      /*
      while (FlagMainFormIsOnTheScreen == false)
      {
        //Thread.Sleep(50);
      }
      */

      TmStart.Tick -= EventTimerTickStartWork;
      TmStart.Stop();

      //Service.PrepareToWorkStep1();
      //Service.PrepareToWorkStep2();
    }
  }
}