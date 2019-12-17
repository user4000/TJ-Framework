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
    }

    private void EventTestQueue(object sender, EventArgs e)
    {
      //TxtMessage.Text = TJFrameworkManager.Service.AlertService.TestQueueAlert();
    }

    private void EventTestMessage5(object sender, EventArgs e)
    {
      string message = "Сообщение из не UI-потока";
      
      int x = 1;

      System.Timers.Timer MyTimer = new System.Timers.Timer(1000);
      MyTimer.Elapsed += (s, arg)
        =>
      {
        Ms.ShortMessage(MsgType.Debug, message + " " + x.ToString(), 500, null, MsgPos.TopLeft,11).CloseOnClick().ToFile().Create();
        x++;
        if (x > 7) MyTimer.Enabled = false;
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
