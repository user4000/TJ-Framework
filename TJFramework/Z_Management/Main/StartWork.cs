using System;
using System.Threading;
using TJFramework.Form;
using TJFramework.Logger;
using System.Windows.Forms;
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

      //Task.Run(() => EventStartBackground()); // Этот метод будет выполняться в UI-потоке //

      /*
      TmStart.Interval = 500;
      TmStart.Tick += new EventHandler(EventTimerStartWork);
      TmStart.Start();
      */

      Application.Run(context);
    }

    private static FxMain CreateMainForm()
    {
      if (MainForm != null) // Данный метод должен быть вызван ровно 1 раз //
      {
        throw new ApplicationException("Method << CreateMainForm() >> has been called more than one time!");
      }

      // if (MainForm != null) return MainForm;

      /* =========================================================================================================================== */
      MainForm = new FxMain();
      MainForm.Text = string.Empty;





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


      if (FrameworkSettings.VisualEffectOnStart)
      {
        MainForm.Opacity = 0;
        MainForm.Visible = true;
        Service.VisualEffectFadeIn();
      }





      MainForm.Show();

      FlagMainFormIsOnTheScreen = true;

      EventStartBackground();

      /* =========================================================================================================================== */

      return MainForm;
    }


    private static void EventStartBackground()
    {
      MainForm.BeginInvoke((Action)delegate { // https://stackoverflow.com/questions/4665539/new-form-on-a-different-thread //

        // Некоторые формы довольно много времени занимают при создании //
        // Поэтому их создание вынесено в отдельный метод, выполняющийся на заднем фоне основного потока //

        TmStart.Interval = 500;
        TmStart.Tick += new EventHandler(EventTimerStartWork);
        TmStart.Start();

        //Service.PrepareToWorkStep1();
        //Service.PrepareToWorkStep2();
      });
    }


    private static void EventTimerStartWork(object sender, EventArgs e)
    {
      // Все трудоёмкие операции выполняем через таймер //

      while(FlagMainFormIsOnTheScreen == false)
      {
        Thread.Sleep(50);
        Application.DoEvents();
      }

    
      Service.PrepareToWorkStep1();
      Application.DoEvents();

      Service.PrepareToWorkStep2();
      Application.DoEvents();

      TmStart.Tick -= EventTimerStartWork;
      TmStart.Stop();
    }
  }
}