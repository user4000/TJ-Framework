using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using TJFramework;
using static TJFramework.TJFrameworkManager;

namespace TJFrameworkExample
{
  public partial class FxTestTwo : RadForm, IEventStartWork
  {
    public FxTestTwo()
    {
      InitializeComponent();
    }

    public void EventStartWork()
    {
      BtnMessage1.Click += EventTestMessage1;
      BtnMessage2.Click += EventTestMessage2;
      BtnMessage3.Click += EventTestMessage3;
      BtnMessage4.Click += EventTestMessage4;
      BtnMessage5.Click += EventTestMessage5;
      BtnTestQueue.Click += EventTestQueue;
      BxTest1.Click += EventTest1;
      BxTest2.Click += EventTest2;
      BxTest3.Click += EventTest3;
      BxTest4.Click += EventTest4;
      BxTest5.Click += EventTest5;
      BxTest6.Click += EventTest6;
      BxTestMainFormPanels.Click += EventTestMainFormPanels;
      BxHideMainFormPanels.Click += EventHideMainFormPanels;
    }

    private void EventHideMainFormPanels(object sender, EventArgs e)
    {
      MainForm.MainFormMenu.Visible = false;
      MainForm.PnMainTop.Visible = false;
      MainForm.PnMainSide.Visible = false;
      MainForm.SplitterMainHorizontal.Visible = false;
      MainForm.SplitterMainVertical.Visible = false;
    }

    private void EventTestMainFormPanels(object sender, EventArgs e)
    {
      MainForm.SplitterMainHorizontal.Visible = true;
      MainForm.SplitterMainVertical.Visible = true;
      MainForm.PnMainTop.Visible = true;
      MainForm.PnMainSide.Visible = true;
      MainForm.MainFormMenu.Visible = true;
    }

    private void EventTest1(object sender, EventArgs e)
    {
      Ms.Message("Привет вам, уважаемые друзья и любители замечательного языка программирования C#, вы сейчас видите тестовое сообщение для всплывающего окошка", "Данная кнопка тестирует сообщение, которое программа выводит на экран в виде всплывающего окошка")
        .Wire(BxTest1).Delay(3).CloseOnClick().Debug();
    }

    private void EventTest2(object sender, EventArgs e)
    {
      Ms.Message("Привет вам, уважаемые друзья и любители замечательного языка программирования C#, вы сейчас видите тестовое сообщение для всплывающего окошка", "Данная кнопка тестирует сообщение, которое программа выводит на экран в виде всплывающего окошка")
        .Wire(BxTest2).Delay(3).CloseOnClick().Info();
    }

    private void EventTest3(object sender, EventArgs e)
    {
      Ms.Message("Привет вам, уважаемые друзья и любители замечательного языка программирования C#, вы сейчас видите тестовое сообщение для всплывающего окошка", "Данная кнопка тестирует сообщение, которое программа выводит на экран в виде всплывающего окошка")
        .Wire(BxTest3).Delay(3).CloseOnClick().Ok();
    }

    private void EventTest4(object sender, EventArgs e)
    {
      Ms.Message("Привет, уважаемые друзья, вы сейчас видите тестовое сообщение для всплывающего окошка", "Данная кнопка тестирует сообщение, которое программа выводит на экран в виде всплывающего окошка")
        .Wire(BxTest4).Delay(3).CloseOnClick().Fail();
    }

    private void EventTest5(object sender, EventArgs e)
    {
      Ms.Message("Привет, уважаемые друзья, вы сейчас видите тестовое сообщение для всплывающего окошка", "Данная кнопка тестирует сообщение, которое программа выводит на экран в виде всплывающего окошка")
        .Wire(BxTest5).Delay(3).CloseOnClick().Warning();
    }

    private void EventTest6(object sender, EventArgs e)
    {
      Ms.Message("Привет, уважаемые друзья, вы сейчас видите тестовое сообщение для всплывающего окошка", "Данная кнопка тестирует сообщение, которое программа выводит на экран в виде всплывающего окошка")
        .Wire(BxTest6).Delay(3).CloseOnClick().Error();
    }

    private void EventTestQueue(object sender, EventArgs e)
    {
      //TxtMessage.Text = TJFrameworkManager.Service.AlertService.TestQueueAlert();
    }

    private void EventTestMessage5(object sender, EventArgs e)
    {
      string message = "Сообщение из не UI-потока";

      EventTestMessage51(sender, e);
      EventTestMessage52(sender, e);

      int x = 1;

      System.Timers.Timer MyTimer = new System.Timers.Timer(1000);
      MyTimer.Elapsed += (s, arg)
        =>
      {
        Ms.ShortMessage(MsgType.Ok, message + " " + x.ToString(), 500, null, MsgPos.TopLeft,11).CloseOnClick().ToFile().Create();
        x++;
        if (x > 7) MyTimer.Enabled = false;
      };
      MyTimer.Enabled = true;
    }


    private void EventTestMessage51(object sender, EventArgs e)
    {
     // string message = "Это сообщение - из не UI-потока";

      int x = 1;

      System.Timers.Timer MyTimer = new System.Timers.Timer(50);
      MyTimer.Elapsed += (s, arg)
        =>
      {
        Ms.Message(Faker.Internet.SecureUrl(), Faker.Lorem.Paragraph(1)).NoAlert().Info();
        x++;
        if (x > 107) MyTimer.Enabled = false;
      };
      MyTimer.Enabled = true;
    }


    private void EventTestMessage52(object sender, EventArgs e)
    {
      // string message = "Это сообщение - из не UI-потока";

      int x = 1;

      System.Timers.Timer MyTimer = new System.Timers.Timer(177);
      MyTimer.Elapsed += (s, arg)
        =>
      {
        Ms.Message(Faker.Internet.SecureUrl(), Faker.Lorem.Paragraph(1)).NoAlert().Debug();
        x++;
        if (x > 107) MyTimer.Enabled = false;
      };
      MyTimer.Enabled = true;
    }

    private void EventTestMessage4(object sender, EventArgs e)
    {
      string message = "Короткое сообщение в одну строку";
      Ms.ShortMessage(MsgType.Info, message, 300, LbFormTwo).CloseOnClick().Delay(12).Create();
    }

    private void EventTestMessage3(object sender, EventArgs e)
    {
      try
      {
        int i = 2312; int z = 0;
        int y = i / z;
      }
      catch  (Exception ex)
      {
        Ms.Error("method EventTestMessage3", ex).File(false).Position(MsgPos.TopCenter).Create();
      }
    }

    private void EventTestMessage2(object sender, EventArgs e)
    {
      string message = "В сибирских городах часто встречаются учителя из ссыльных поселенцев; ими не брезгают. Учат же они преимущественно французскому языку, столь необходимому на поприще жизни и о котором без них в отдаленных краях Сибири не имели бы и понятия. В первый раз я встретил Александра Петровича в доме одного старинного, заслуженного и хлебосольного чиновника, Ивана Иваныча Гвоздикова, у которого было пять дочерей, разных лет, подававших прекрасные надежды. Александр Петрович давал им уроки четыре раза в неделю, по тридцати копеек серебром за урок. Наружность его меня заинтересовала. Это был чрезвычайно бледный и худой человек, еще нестарый, лет тридцати пяти, маленький и тщедушный. Одет был всегда весьма чисто, по-европейски.";
      Ms.Message(MsgType.Fail, "Это проверка метода Message", message, null, MsgPos.Unknown, 15).Size(300, 400).CloseOnClick().Create();
    }

    private void EventTestMessage1(object sender, EventArgs e)
    {
      string message = "Сообщение 123 привет! Сообщение 123 привет! Сообщение 123 привет! Сообщение 123 привет! Сообщение 123 привет! Сообщение 123 привет!";
      message += message;
      message += message;

      Ms.Message("Тестирование. Заголовок сообщения.", message).Control(LbFormTwo).Position(MsgPos.ScreenCenter).PinButton().Delay(15).Ok();
    }
  }
}
