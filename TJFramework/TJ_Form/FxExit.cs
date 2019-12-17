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
      if (TJFrameworkManager.FrameworkSettings.ConfirmExitButtonText.Length > 0)
      {
        BtnExit.Visible = true;
        BtnExit.Text = TJFrameworkManager.FrameworkSettings.ConfirmExitButtonText;
      }
      else
      {
        BtnExit.Visible = false;
      }
    }
  }
}
