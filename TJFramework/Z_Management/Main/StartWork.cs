using System;
using System.Threading;
using TJFramework.Form;
using System.Windows.Forms;
using System.Threading.Tasks;
using TJFramework.FrameworkSettings;

namespace TJFramework
{
  public partial class TJFrameworkManager
  {
    private static bool FlagMainFormIsOnTheScreen { get; set; } = false;

    private static ushort MainFormClosingCounter { get; set; } = 0;

    internal static bool UserHasClickedExitButton { get; set; } = false;




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



      MainForm = new FxMain();
      MainForm.Visible = false;
      MainForm.Text = string.Empty;



      //MainForm.Load += new EventHandler(EventFormLoad);


      MainForm.Shown += new EventHandler(EventMainFormShown);

      MainForm.FormClosing += new FormClosingEventHandler(EventMainFormClosing);



      if (FrameworkSettings.VisualEffectOnStart)
      {
        MainForm.Opacity = 0;
      }



      // Если пользователь хочет применить тему приложения, то сделаем это по части имени темы //
      if (string.IsNullOrWhiteSpace(FrameworkSettings.ThemeName) == false)
      {
        Service.SrvTheme.SetApplicationAppearance(FrameworkSettings.ThemeName, null);
      }



      if (FrameworkSettings.FlagMainPageViewVisibleWhileMainFormIsStarting == false)
      {
        MainForm.MainPageView.Visible = false;
      }
      


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

      return MainForm;
    }







    private static async void EventMainFormClosing(object sender, FormClosingEventArgs e)
    {
      // ------------------------------------------------------------------------------------------------------------- //
      if ((FrameworkSettings.MainFormCloseButtonActsAsMinimizeButton) && (UserHasClickedExitButton == false))
      {
        MainForm.WindowState = FormWindowState.Minimized;
        e.Cancel = true;
        return;
      }
      // ------------------------------------------------------------------------------------------------------------- //
      if ((FrameworkSettings.MainFormCloseButtonMustNotCloseForm) && (UserHasClickedExitButton == false))
      {
        e.Cancel = true;
        return;
      }
      // ------------------------------------------------------------------------------------------------------------- //


      if (MainFormClosingCounter > 0) return;





      /*************************************/

      e.Cancel = true;


      if ((FrameworkSettings.MainFormMinimizeBeforeClosing) && (MainForm.WindowState != FormWindowState.Minimized))
      {
        MainForm.WindowState = FormWindowState.Minimized;
        await Task.Delay(500);
      }


      await Service.MainExit();

      MainFormClosingCounter++;


      MainForm.Close();


      /*************************************/
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
    }
  }
}