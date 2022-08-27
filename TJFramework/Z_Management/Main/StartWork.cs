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






    private static async void EventMainFormClosing(object sender, FormClosingEventArgs e) // Событие: поступил сигнал "Закрыть главную форму приложения" //
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

      if (MainFormClosingCounter > 0) return; // Со второго захода выполнится инструкция return в данном условии //

      /* =============================================================================================================== */

      // Всё, что ниже этого комментария выполнится только 1 раз с первого захода. 
      // А со второго захода в этом методе выполнение до этой строки уже не дойдёт (см. инструкцию return выше).

      e.Cancel = true; // С первого раза этот метод не закроет форму. А со второго захода закроет. И в этом нам поможет переменная MainFormClosingCounter //



      TJFrameworkManager.FrameworkSettings.Save();      // Записать местоположение формы и её размер нужно до того, как мы её минимизируем //
      MainForm.WindowState = FormWindowState.Minimized; // Очень важная строка //
      await Task.Delay(500);

      // Если не выполнить строку MainForm.WindowState = FormWindowState.Minimized; 
      // тогда программа может выдать исключение "Ошибка при создании дескриптора окна".
      // System.ComponentModel.Win32Exception: Error creating window handle.
      // Причём это происходит для приложения, которое было свёрнуто в system tray и потом заново активировано двойным кликом по иконке.



      await Service.MainExit();

      MainFormClosingCounter++;

      MainForm.Close();

      /* =============================================================================================================== */
    }
  }
}