using System;
using TJFramework;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TJFramework.Form
{
  public partial class FxExit : RadForm, IEventStartWork
  {
    public FxExit()
    {
      InitializeComponent();
    }

    public bool ExitWithoutConfirmation { get => string.IsNullOrWhiteSpace(TJFrameworkManager.FrameworkSettings.ConfirmExitButtonText); }




    public void EventStartWork()
    {
      ConfigureExitButton();
      BtnExit.MinimumSize = new System.Drawing.Size(250, 0);
    }

    public void EventUserVisitedThisPage()
    {
      ConfigureExitButton();
    }

    public void ConfigureExitButton()
    {
      string text = TJFrameworkManager.FrameworkSettings.ConfirmExitButtonText;

      //RadMessageBox.Show($"TJFramework.Form.FxExit  TEST:   ConfirmExitButtonText = {text}");


      if ( string.IsNullOrWhiteSpace(text) )
      {
        BtnExit.Visible = false;
      }
      else
      {
        if (BtnExit.Text != text) BtnExit.Text = text;
        BtnExit.Visible = true;
      }
    }
  }
}