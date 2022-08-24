﻿using System;
using TJFramework;
using TJFramework.Form;
using System.Windows.Forms;
using System.Threading.Tasks;
using TJFramework.ApplicationSettings;
using static TJFramework.Logger.Manager;
using static TJFramework.TJFrameworkManager;

namespace TJFramework
{
  public partial class TJService
  {

    private void EventButtonExitClick(object sender, EventArgs e)
    {
      FormExit.BtnExit.Enabled = false;
      FormExit.BtnExit.Visible = false;
      CloseMainForm();
    }


    internal void CloseMainForm()
    {
      UserHasClickedExitButton = true;
      MainForm.Close();
    }



    internal async Task MainExit()
    {
      UserHasClickedExit = true;

      EventBeforeMainFormClose?.Invoke();

      if (FuncBeforeMainFormClose != null)
      {
        VisualEffectFadeOut();

        //Application.DoEvents();
       

        MainForm.Opacity = 0;
        MainForm.ShowInTaskbar = false;

        //Application.DoEvents();

        Task task = FuncBeforeMainFormClose();
        if (task != null) await task;

        //Application.DoEvents();
      }

      MainPageViewManager.LaunchCloseHandlerOfEachChildForm();

      TJFrameworkManager.FrameworkSettings.Save();

      if (FuncBeforeMainFormClose == null) VisualEffectFadeOut();
    }
  }
}