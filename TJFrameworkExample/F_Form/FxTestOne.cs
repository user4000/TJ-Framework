using System;
using TJFramework;
using Telerik.WinControls.UI;
using static TJFramework.TJFrameworkManager ;

namespace TJFrameworkExample
{
  public partial class FxTestOne : RadForm, IEventStartWork
  {
    public FxTestOne()
    {
      InitializeComponent();
    }

    public void EventStartWork()
    {
      this.BtnEnable.Click += TestPageEnable;
      this.BtnDisable.Click += TestPageDisable;
      this.BtnShow.Click += TestPageShow;
      this.BtnHide.Click += TestPageHide;
      this.BtnGoto.Click += TestPageGoto;
      this.BtnAlert.Click += TestAlert;
      this.BtnMessage.Click += TestMessage;
      this.BtnPageViewOrientation.Click += TestPageViewOrientation;
    }

    private void TestPageViewOrientation(object sender, EventArgs e)
    {
      TJFrameworkManager.Service.SetMainPageViewOrientation(StripViewAlignment.Bottom);
    }

    private void TestMessage(object sender, EventArgs e)
    {
      Ms.Message("aaaa", "bbbb").Control(BtnMessage).Delay(3).Size(330, 123).Offset(-34,56).Info();
    }

    private void TestAlert(object sender, EventArgs e)
    {
      Ms.Message("Hello !", "This is a test message").Control(BtnAlert).Delay(3).Size(330, 78).Offset(145, -156).Ok();
    }

    private void TestPageEnable(object sender, EventArgs e)
    {
      if (LvNumbers.SelectedItem == null) return;
      switch (LvNumbers.SelectedItem.Text)
      {
        case "1": TJFrameworkManager.Pages.EnablePage<FxTestOne>(true); break;
        case "2": TJFrameworkManager.Pages.EnablePage<FxTestTwo>(true); break;
        case "3": TJFrameworkManager.Pages.EnablePage<FxTestThree>(true); break;
      }
    }

    private void TestPageDisable(object sender, EventArgs e)
    {
      if (LvNumbers.SelectedItem == null) return;
      switch (LvNumbers.SelectedItem.Text)
      {
        case "1": TJFrameworkManager.Pages.EnablePage<FxTestOne>(false); break;
        case "2": TJFrameworkManager.Pages.EnablePage<FxTestTwo>(false); break;
        case "3": TJFrameworkManager.Pages.EnablePage<FxTestThree>(false); break;
      }
    }

    private void TestPageShow(object sender, EventArgs e)
    {
      if (LvNumbers.SelectedItem == null) return;
      switch (LvNumbers.SelectedItem.Text)
      {
        case "1": TJFrameworkManager.Pages.ShowPage<FxTestOne>(true); break;
        case "2": TJFrameworkManager.Pages.ShowPage<FxTestTwo>(true); break;
        case "3": TJFrameworkManager.Pages.ShowPage<FxTestThree>(true); break;
      }
    }

    private void TestPageHide(object sender, EventArgs e)
    {
      if (LvNumbers.SelectedItem == null) return;
      switch (LvNumbers.SelectedItem.Text)
      {
        case "1": TJFrameworkManager.Pages.ShowPage<FxTestOne>(false); break;
        case "2": TJFrameworkManager.Pages.ShowPage<FxTestTwo>(false); break;
        case "3": TJFrameworkManager.Pages.ShowPage<FxTestThree>(false); break;
      }
    }

    private void TestPageGoto(object sender, EventArgs e)
    {
      if (LvNumbers.SelectedItem == null) return;
      switch (LvNumbers.SelectedItem.Text)
      {
        case "1": TJFrameworkManager.Pages.GotoPage<FxTestOne>(); break;
        case "2": TJFrameworkManager.Pages.GotoPage<FxTestTwo>(); break;
        case "3": TJFrameworkManager.Pages.GotoPage<FxTestThree>(); break;
      }
    }
  }
}