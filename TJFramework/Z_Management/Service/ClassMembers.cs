using System;
using TJFramework.Form;
using TJFramework.Themes;
using Telerik.WinControls.UI;
using System.Threading.Tasks;
using System.Collections.Generic;
using TJFramework.ApplicationSettings;

namespace TJFramework
{
  public partial class TJService
  {
    public CxThemeManager SrvTheme { get; } = new CxThemeManager();

    public RadPageView MainPageView { get; private set; } = null;

    public TJAlertService AlertService { get; private set; } = null;

    internal TJPageView MainPageViewManager { get; } = new TJPageView();

    internal TJStandardApplicationSettings ProjectDefaultApplicationSettings { get; private set; } = null;  // Default settings before loading from file //

    internal TJStandardApplicationSettings CurrentApplicationSettings { get; private set; } = null;

    internal Queue<TJChildForm> QueueChildForms { get; } = new Queue<TJChildForm>();





    internal bool FlagPrepareToWorkStep1 { get; private set; } = false;

    internal bool FlagPrepareToWorkStep2 { get; private set; } = false;


    private byte CountOfMessageTypes { get; } = (byte)Enum.GetNames(typeof(MsgType)).Length;

    internal byte GetIndexByMessageType(MsgType type) => (byte)(((byte)type) % CountOfMessageTypes);


    public FxMain MainForm { get; private set; } = null;

    public FxSettings FormSettings { get; private set; } = null;

    public FxLog FormLog { get; private set; } = null;

    public FxExit FormExit { get; private set; } = null;






    public bool MainFormIsBeingResized { get; private set; } = false;

    public bool UserHasClickedExit { get; private set; } = false;

    public bool MainFormIsBeingDisappeared { get; private set; }


    public Action EventBeforeAnyFormStartHandlerLaunched { get; set; } = null;

    public Action EventMainFormLoadBeforeAnyFormIsCreated { get; set; } = null;

    public Action EventMainFormLoadBeforeAnyCustomFormIsCreated { get; set; } = null;

    public Action EventAfterAllFormsAreCreated { get; set; } = null;

    public Action EventBeforeMainFormClose { get; set; } = null;

    public Func<Task> FuncBeforeMainFormClose { get; set; } = null;

    public Action<string> EventPageChanged { get; set; } = null;



    internal string StartPageName { get; private set; } = string.Empty;

    internal string MainFormCaption { get; private set; } = string.Empty;

  }
}