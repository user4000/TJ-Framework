using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TJFramework.ApplicationSettings;
using TJFramework.Form;
using static TJFramework.Logger.Manager;
using static TJFramework.TJFrameworkManager;

namespace TJFramework
{
  public class TJService
  {
    public RadPageView MainPageView { get; private set; } = null;

    public TJAlertService AlertService { get; private set; } = null;

    internal TJPageView MainPageViewManager { get; } = new TJPageView();

    internal TJStandardApplicationSettings ProjectDefaultApplicationSettings { get; private set; } = null;  // Default settings before loading from file //

    internal TJStandardApplicationSettings CurrentApplicationSettings { get; private set; } = null;

    internal Queue<TJChildForm> QueueChildForms { get; } = new Queue<TJChildForm>();

    internal int CounterEventFormShow { get; private set; } = 0;

    private byte CountOfMessageTypes { get; } = (byte)Enum.GetNames(typeof(MsgType)).Length;

    internal byte GetIndexByMessageType(MsgType type) => (byte)(((byte)type) % CountOfMessageTypes);

    internal FxMain MainForm { get; private set; } = null;

    public FxSettings FormSettings { get; private set; } = null;

    public FxLog FormLog { get; private set; } = null;

    public FxExit FormExit { get; private set; } = null;

    public bool MainFormIsBeingResized { get; private set; } = false;

    internal bool UserHasClickedExit { get; set; } = false;

    internal bool MainFormIsBeingDisappeared { get; private set; }

    public Action EventBeforeAnyFormStartHandlerLaunched { get; set; } = null;

    public Action EventMainFormLoadBeforeAnyFormIsCreated { get; set; } = null;

    public Action EventMainFormLoadBeforeAnyCustomFormIsCreated { get; set; } = null;

    public Action EventAfterAllFormsAreCreated { get; set; } = null;

    public Action EventBeforeMainFormClose { get; set; } = null;

    public Action<string> EventPageChanged { get; set; } = null;

    public Task EventBeforeMainFormCloseAsync { get; set; } = null;

    internal string StartPageName { get; private set; } = string.Empty;

    internal string MainFormCaption { get; private set; } = string.Empty;

    /* ===================================================================================== */
    internal void InitMainForm(FxMain form) => MainForm = form;

    private void SetCurrentSettings(TJStandardApplicationSettings inputSettings) => CurrentApplicationSettings = inputSettings ?? CurrentApplicationSettings;

    public string GetFormName<T>() where T : RadForm => typeof(T).FullName;

    internal bool CheckPage<T>(string pageName) where T : RadForm => pageName == GetFormName<T>();

    internal void CreateMainPageView() => MainPageView = MainPageViewManager.Create(MainForm);

    internal Image GetImageByMessageType(MsgType MessageType) => FormLog.ImageIcons.Images[GetIndexByMessageType(MessageType)];

    public void StartPage<T>() where T : RadForm
    {
      string TypeOfForm = GetFormName<T>();
      if (TypeOfForm == GetFormName<FxExit>()) return;
      if (TypeOfForm == GetFormName<FxLog>()) return;
      if (TypeOfForm == GetFormName<FxMain>()) return;
      StartPageName = TypeOfForm;
    }

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

    internal void ConfigureApplicationSettings(TJStandardApplicationSettings settings)
    {
      ProjectDefaultApplicationSettings = settings;
      SetCurrentSettings(settings);
    }

    private void SetChildFormSettings(RadForm radForm)
    {
      radForm.Dock = DockStyle.Fill;
      radForm.FormBorderStyle = FormBorderStyle.None;
      radForm.Visible = true;
      radForm.BringToFront();
    }

    public void AddForm<T>(string pageText) where T : RadForm, new()
    {
      string pageName = GetFormName<T>();
      TJChildForm childForm = TJChildForm.Create<T>(pageName, pageText);
      if (childForm.IncorrectPageName == false) QueueChildForms.Enqueue(childForm);
    }

    private void AddFormToPage(TJChildForm childForm)
    {
      if (MainPageViewManager.PageExists(childForm.PageName)) return;
      if (childForm.IncorrectPageName) return;

      RadPageViewPage page = new RadPageViewPage() { Name = childForm.PageName };

      MainPageViewManager.Add(page);
      MainPageViewManager.Add(childForm);

      page.Text = childForm.PageText;
      MainPageViewManager.SetPageStandardView(page);

      childForm.ChildForm.TopLevel = false; /* It is very important */
      SetChildFormSettings(childForm.ChildForm);
      page.Controls.Add(childForm.ChildForm);

      CheckIsSettingsForm(childForm.ChildForm);
      CheckIsLogForm(childForm.ChildForm);
      CheckIsExitForm(childForm.ChildForm);
    }

    internal void CheckIsExitForm(RadForm radForm)
    {
      if ((radForm is FxExit) && (FormExit == null))
      {
        FormExit = (FxExit)radForm;
        FormExit.BtnExit.Click += async (s, e) => await EventButtonExitClick(s, e);
      }
    }

    internal void CheckIsLogForm(RadForm radForm)
    {
      if ((radForm is FxLog) && (FormLog == null))
      {
        FormLog = (FxLog)radForm;
        AlertService = new TJAlertService(this, FormLog);
      }
    }

    private async Task EventButtonExitClick(object sender, EventArgs e)
    {
      FormExit.BtnExit.Enabled = false;
      FormExit.BtnExit.Visible = false;
      await MainExit();
    }

    internal void CheckIsSettingsForm(RadForm radForm)
    {
      if ((ProjectDefaultApplicationSettings != null) && (radForm is FxSettings) && (FormSettings == null))
      {
        FormSettings = (FxSettings)radForm;
        TJStandardApplicationSettings loadedSettings = null;
        try
        {
          loadedSettings = CurrentApplicationSettings;
          SetCurrentSettings(loadedSettings); // Set just loaded settings as current settings //
        }
        catch (Exception ex)
        {
          ProjectDefaultApplicationSettings.LinkToPropertyGrid(FormSettings.GxProperty);
          Log.Save(MsgType.Error, "An error has occured during loading application settings.", "");
          Log.Save(ex, "method name = [IsSettingsForm]");
        }
        FormSettings.AcceptLoadedSettings(loadedSettings);
      }
    }

    public void CreateApplicationSettings<T>() where T : TJStandardApplicationSettings, new()
    {
      T settingsDefault = new T(); // Create instance of concrete user settings //
      T localSettingsCurrent = settingsDefault;
      /* Since JSON Serializer cannot save attributes of members of [Settings] class we need this workaround */
      try { localSettingsCurrent = TJStandardUserSettingsLoader<T>.LoadFromJSONFile(); }
      catch { localSettingsCurrent = settingsDefault; }

      CurrentApplicationSettings = localSettingsCurrent;
      ConfigureApplicationSettings(localSettingsCurrent);
    }

    internal void CreateFormsFromQueue()
    {
      foreach (TJChildForm childForm in QueueChildForms) AddFormToPage(childForm);  /* then we create other child forms */
      QueueChildForms.Clear();
      Pages.GotoPage(StartPageName);
    }

    internal void CreateFormLog() => AddForm<FxLog>(TJFrameworkManager.FrameworkSettings.HeaderFormLog);

    internal void CreateFormSettings() => AddForm<FxSettings>(TJFrameworkManager.FrameworkSettings.HeaderFormSettings);

    internal void CreateFormExit() => AddForm<FxExit>(TJFrameworkManager.FrameworkSettings.HeaderFormExit);

    internal void VisualEffectFadeIn()
    {
      if (!TJFrameworkManager.FrameworkSettings.VisualEffectOnStart) return;
      int duration = 200; // in milliseconds
      int steps = 20;
      Timer timer = new Timer() { Interval = duration / steps };
      int currentStep = 0;
      timer.Tick += (arg1, arg2) =>
      {
        MainForm.Opacity = ((double)currentStep) / steps;
        currentStep++;

        if (currentStep >= steps)
        {
          timer.Stop();
          timer.Dispose();
          MainForm.Opacity = 1;
        }
      };
      timer.Start();
    }

    internal void VisualEffectFadeOut()
    {
      if (!TJFrameworkManager.FrameworkSettings.VisualEffectOnExit) return;
      int duration = 250; // milliseconds //
      int steps = 25;

      if (MainFormIsBeingDisappeared) return;
      MainFormIsBeingDisappeared = true;

      bool formMayBeClosed = false;

      Timer timer = new Timer() { Interval = duration / steps };

      int currentStep = 0;

      timer.Tick += (arg1, arg2) =>
      {
        MainForm.Opacity = 1 - ((double)currentStep) / steps;

        currentStep++;
        if (currentStep > steps / 2) { currentStep++; };
        if (currentStep > 3 * steps / 4) { currentStep++; currentStep++; };

        if (currentStep >= steps)
        {
          timer.Stop();
          timer.Dispose();
          formMayBeClosed = true;
        }
      };

      timer.Start();
      while (formMayBeClosed == false) { Application.DoEvents(); };
    }

    internal void SetEventsForMainForm()
    {
      void EventMainFormResizeBegin(object sender, EventArgs e) => MainFormIsBeingResized = true;
      void EventMainFormResizeEnd(object sender, EventArgs e) => MainFormIsBeingResized = false;
      void EventMainFormResize(object sender, EventArgs e)
      {
        if (!TJFrameworkManager.FrameworkSettings.MainFormMinimizeToTray) return;
        if (MainForm.WindowState == FormWindowState.Minimized) { MainForm.Hide(); MainForm.MyNotifyIcon.Visible = true; }
      }

      void EventNotifyIconMouseDoubleClick(object sender, MouseEventArgs e)
      {
        if (!TJFrameworkManager.FrameworkSettings.MainFormMinimizeToTray) return;
        MainForm.Show(); MainForm.WindowState = FormWindowState.Normal; MainForm.MyNotifyIcon.Visible = false;
      }

      MainForm.Load += EventMainFormLoad;
      MainForm.Shown += EventMainFormShown;
      MainForm.ResizeBegin += EventMainFormResizeBegin;
      MainForm.ResizeEnd += EventMainFormResizeEnd;
      MainForm.Resize += EventMainFormResize;
      MainForm.MyNotifyIcon.MouseDoubleClick += EventNotifyIconMouseDoubleClick;
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

    public void SetMainPageViewOrientation(StripViewAlignment Alignment) => MainPageViewManager.SetMainPageViewTabOrientation(Alignment);

    private void EventMainFormLoad(object sender, EventArgs e)
    {
      MainForm.Visible = false;
      //EventMainFormSizeChanged();
      SetMainFormMinimumSize();
      SetMainFormSize();
      CreateMainPageView();
      //EventSelectedPageChanged();
      if (TJFrameworkManager.FrameworkSettings.VisualEffectOnStart) MainForm.Opacity = 0;
      EventMainFormLoadBeforeAnyFormIsCreated?.Invoke();
      CreateFormSettings();
      CreateFormLog();
      CreateFormExit();
      EventMainFormLoadBeforeAnyCustomFormIsCreated?.Invoke();
      CreateFormsFromQueue(); // Create all of the child forms in the Queue //
      TJFrameworkManager.FrameworkSettings.RestoreMainFormLocationAndSize();
      MainPageView.BringToFront();
      MainForm.Text = MainFormCaption;
      MainForm.MyNotifyIcon.Text = MainFormCaption;
      MainForm.Icon = MainForm.MyNotifyIcon.Icon;
      MainForm.Visible = true;
      VisualEffectFadeIn();
    }

    internal void EventMainFormShown(object sender, EventArgs e)
    {
      if (CounterEventFormShow == 0) // These events must be executed only one time //
      {
        CounterEventFormShow++;
        EventBeforeAnyFormStartHandlerLaunched?.Invoke();
        MainPageViewManager.LaunchStartHandlerOfEachChildForm();
        SetEventMainPageViewSelectedPageChanged();
        EventAfterAllFormsAreCreated?.Invoke();
      }
    }

    internal void SetEventMainPageViewSelectedPageChanged()
    {
      MainPageView.SelectedPageChanged += async (s, e) =>
      {
        string PageName = MainPageView.SelectedPage.Name;

        if (EventPageChanged != null) EventPageChanged.Invoke(PageName);

        if (CheckPage<FxSettings>(PageName))
        {
          FormSettings.EventUserVisitedThisPage();
        }

        if (CheckPage<FxExit>(PageName))
        {
          if (FormExit.ExitWithoutConfirmation) await MainExit();
        }

        if (CheckPage<FxLog>(PageName))
        {
          FormLog.EventUserVisitedThisPage();
        }
      };
    }

    internal async Task MainExit()
    {
      UserHasClickedExit = true;
      EventBeforeMainFormClose?.Invoke();
      if (EventBeforeMainFormCloseAsync != null)
      {
        VisualEffectFadeOut();
        Application.DoEvents();
        MainForm.Opacity = 0;
        MainForm.ShowInTaskbar = false;
        Application.DoEvents();
        await EventBeforeMainFormCloseAsync;
        Application.DoEvents();
      }
      MainPageViewManager.LaunchCloseHandlerOfEachChildForm();
      TJFrameworkManager.FrameworkSettings.Save();
      if (EventBeforeMainFormCloseAsync == null) VisualEffectFadeOut();
      MainForm.Close();
    }
  }
}
