using System;
using Telerik.WinControls.UI;

namespace TJFramework.Form
{
  public partial class FxExit : RadForm, IEventStartWork
  {
    public FxExit()
    {
      InitializeComponent();
    }

    public bool ExitWithoutConfirmation { get => !BtnExit.Visible; }

    public void EventStartWork()
    {
      ConfigureExitButton();
    }

    public void ConfigureExitButton()
    {
      if ( string.IsNullOrWhiteSpace( TJFrameworkManager.FrameworkSettings.ConfirmExitButtonText ) )
      {
        BtnExit.Visible = false;
      }
      else
      {
        BtnExit.Visible = true;
        BtnExit.Text = TJFrameworkManager.FrameworkSettings.ConfirmExitButtonText;
      }
    }
  }
}