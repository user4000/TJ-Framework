using System;
using System.Drawing;
using TJFramework.Form;
using System.Windows.Forms;

namespace TJFramework
{
  public partial class TJService
  {
    internal void InitMainForm(FxMain form) => MainForm = form;


    internal void SetMainFormSize()
    {
      int intMargin = TJFrameworkManager.FrameworkSettings.MainFormMargin;
      MainForm.Location = new Point(intMargin, intMargin);
      MainForm.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width - intMargin * 2, Screen.PrimaryScreen.WorkingArea.Height - intMargin * 2);
    }

    internal void SetMainFormMinimumSize()
    {
      MainForm.MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width / 2, 100 + Screen.PrimaryScreen.WorkingArea.Height / 2);
    }

    internal void RestoreMainFormLocationAndSize(Point location, Size size)
    {
      if ((location.X < 0) || (location.Y < 0))
      {
        location = new Point(20, 20);
      }

      if ((size.Width < MainForm.MinimumSize.Width) || (size.Height < MainForm.MinimumSize.Height))
      {
        size = new Size(MainForm.MinimumSize.Width + 100, MainForm.MinimumSize.Height + 100);
      }

      MainForm.Location = location;
      MainForm.Size = size;
    }


    internal void SetEventsForMainForm()
    {
      void EventMainFormResizeBegin(object sender, EventArgs e) => MainFormIsBeingResized = true;
      void EventMainFormResizeEnd(object sender, EventArgs e) => MainFormIsBeingResized = false;

      void EventMainFormResize(object sender, EventArgs e)
      {
        if (!TJFrameworkManager.FrameworkSettings.MainFormMinimizeToTray) return;
        if (MainForm.WindowState == FormWindowState.Minimized)
        {
          MainForm.ShowInTaskbar = false;
          MainForm.MyNotifyIcon.Visible = true;
          MainForm.Hide();
        }
      }

      void EventNotifyIconMouseDoubleClick(object sender, MouseEventArgs e)
      {
        if (!TJFrameworkManager.FrameworkSettings.MainFormMinimizeToTray) return;
        MainForm.Show();
        MainForm.WindowState = FormWindowState.Normal;
        MainForm.ShowInTaskbar = true;
        //MainForm.MyNotifyIcon.Visible = false;
      }


      //MainForm.Load += new EventHandler(EventMainFormLoad);
      //MainForm.Shown += new EventHandler(EventMainFormShown);

      MainForm.ResizeBegin += new EventHandler(EventMainFormResizeBegin);
      MainForm.ResizeEnd += new EventHandler(EventMainFormResizeEnd);
      MainForm.Resize += new EventHandler(EventMainFormResize);
      MainForm.MyNotifyIcon.MouseDoubleClick += new MouseEventHandler(EventNotifyIconMouseDoubleClick);
    }

    public void SetIcons(Icon MainFormIcon, Icon NotifyIcon = null)
    {
      if (MainFormIcon != null)
      {
        MainForm.Icon = MainFormIcon;
        if (NotifyIcon == null) MainForm.MyNotifyIcon.Icon = MainFormIcon;
      }
      if (NotifyIcon != null) MainForm.MyNotifyIcon.Icon = NotifyIcon;
    }

    public void SetMainFormCaption(string text)
    {
      MainFormCaption = text;
      if (MainForm != null)
      {
        MainForm.Text = text;
        if (MainForm.MyNotifyIcon != null) MainForm.MyNotifyIcon.Text = text;
      }
    }
  }
}