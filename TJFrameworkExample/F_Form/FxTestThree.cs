using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Threading.Tasks;
using System.Linq;
using TJFramework;
using static TJFramework.TJFrameworkManager;

namespace TJFrameworkExample
{
  public partial class FxTestThree : RadForm, IEventStartWork
  {
    private string BigMessage { get; set; } = string.Empty;
    public FxTestThree()
    {
      InitializeComponent();
    }

    public void EventStartWork()
    {
      var list = Faker.Lorem.Paragraphs(1000);
      BigMessage = String.Join(", ", list.Select(o => o.ToString()));
      BxTestBigMessage.Click += EventTestBigMessage;
      BxTestRemovePreviousAlerts.Click += EventTestRemovePreviousAlerts;
    }

    private void EventTestRemovePreviousAlerts(object sender, EventArgs e)
    {
      string header = "Тестирование сообщений " + Faker.Lorem.Sentence(3);
      string message = Faker.Lorem.Sentence(15);
      Ms.Message(header, message).Pos(MsgPos.BottomLeft).RemovePrevious().Delay(8).Debug();
    }

    private async void EventTestBigMessage(object sender, EventArgs e)
    {
      string msg, h;
      Ms.Message("", "Start").NoTable().Wire(BxTestBigMessage).Info();
      for (int i=1; i<101; i++)
      {
        msg = Faker.Lorem.Sentence(20);
        if (i == 55) msg += BigMessage;
        h = msg.Length.ToString() + " === " + Faker.Address.StreetAddress(true) + " " + Faker.Company.CatchPhrase() + " " + Faker.Internet.FreeEmail();
        Ms.Message(h, msg).NoAlert().Debug();
        await Task.Delay(10);
      }
      Ms.Message("", "End").NoTable().Wire(BxTestBigMessage).Ok();
    }
  }
}