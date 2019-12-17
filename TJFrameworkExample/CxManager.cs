using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TJFramework;
using System.Reflection;
using TJFramework.Form;
using static TJFramework.Logger.Manager;

namespace TJFrameworkExample
{
  internal class CxManager 
  {

    internal Timer TimerHideMainForm { get; } = new Timer();

    internal int IdUser { get; private set; } = 0;


    internal FxMain FrmMainForm { get; private set; } = null;
    internal FxTestOne FrmTextOne { get; private set; } = null;
    internal FxTestTwo FrmTextTwo { get; private set; } = null;

    internal bool MainFormIsBeingResized { get; set; } = false;

    internal void EventSelectedPageChanged(string PageUniqueName)
    {
      /*if (PageUniqueName == typeof(RadFormUser).FullName)
      {
        if (FormUserMustResetView)
        {
          FormUserMustResetView = false; ReferenceRadFormUser.ResetView();
        }
      }
      // ----------------------------------------------------------------------------------------- //
      if (PageUniqueName == typeof(RadFormRole).FullName)
      {
        if (FormRoleMustResetView)
        {
          FormRoleMustResetView = false; ReferenceRadFormRole.ResetView(true);         
        }
      }
      // ----------------------------------------------------------------------------------------- //
      if (PageUniqueName == typeof(RadFormCommand).FullName)
      {
        ReferenceRadFormCommand.EventUserSelectedThisForm();
      }*/
    }

    private void EventMainFormResizeEnd(object sender, EventArgs e) => MainFormIsBeingResized = false;

    private void EventMainFormResizeBegin(object sender, EventArgs e) => MainFormIsBeingResized = true;



    internal void EventBeforeMainFormClose()
    {
      //Log.Save(MsgType.Debug, "Test", "EventBeforeMainFormClose()");
    }

    internal async Task EventBeforeMainFormCloseAsync()
    {
      Log.Save(MsgType.Debug, "Начало", "Эмуляция долго выполняющейся задачи");
      await Task.Delay(9000);
      Log.Save(MsgType.Debug, "Окончание", "Эмуляция долго выполняющейся задачи");
    }

    internal void EventPropertyValueChanged(string PropertyName)
    {
      Log.Save(MsgType.Debug, "Manager.EventPropertyValueChanged", PropertyName);
    }

    internal void EventPageChanged(string PageName)
    {
      Log.Save(MsgType.Debug, "Manager.EventMainPageChanged", PageName);

      if (PageName == TJFrameworkManager.Service.GetFormName<FxTestOne>())
      {
        Log.Save(MsgType.Debug, "Выбрана форма номер один.", PageName);
      }

      if (PageName == TJFrameworkManager.Service.GetFormName<FxTestTwo>())
      {
        Log.Save(MsgType.Debug, "Выбрана форма номер два.", PageName);
      }

      if (PageName == TJFrameworkManager.Service.GetFormName<FxTestThree>()) 
      {
        Log.Save(MsgType.Debug, "Выбрана форма номер три.", PageName);
      }

    }
  }
}


