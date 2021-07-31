using Telerik.WinControls.UI;

namespace TJFramework
{
  internal class TJChildForm
  {
    internal RadForm ChildForm { get; private set; } = null;

    internal string PageName { get; } = string.Empty;

    internal string PageText { get; } = string.Empty;

    internal bool FlagTabEnabled { get; } = true; // Активна или отключена верхушка вкладки //

    internal bool FlagTabVisible { get; } = true; // Видима или скрыта верхушка вкладки //

    private TJChildForm(RadForm form, string pageName, string pageText, bool enabled, bool visible)
    { /* Hidden constructor - you must create form only via FACTORY method */
      ChildForm = form;
      PageName = pageName;
      PageText = pageText;
      FlagTabEnabled = enabled;
      FlagTabVisible = visible;
    }

    internal static TJChildForm Create(RadForm form, string pageName, string pageText, bool enabled, bool visible) => new TJChildForm(form, pageName, pageText, enabled, visible);

    internal static TJChildForm Create<T>(string pageName, string pageText, bool enabled, bool visible) where T : RadForm, new()
    {
      return Create(new T(), pageName, pageText, enabled, visible);
    }

    internal bool IncorrectPageName { get => PageName == string.Empty; }

    internal bool HasNoChildForm { get => ChildForm == null; }

    internal bool HasChildForm { get => !HasNoChildForm; }

    internal void DisposeChildForm(bool ExecuteFormEndHandler)
    {
      if (HasChildForm)
      {
        LaunchEndHandler();
        ChildForm.Visible = false;
        ChildForm.Close();
        try { ChildForm.Dispose(); } catch { };
        ChildForm = null;
      }
    }

    internal void LaunchStartHandler()
    {
      if ((ChildForm != null) && (ChildForm is IEventStartWork))
      {
        IEventStartWork form = (IEventStartWork)ChildForm;
        form.EventStartWork();
      };
    }

    internal void LaunchEndHandler()
    {
      if ((ChildForm != null) && (ChildForm is IEventEndWork))
      {
        IEventEndWork form = (IEventEndWork)ChildForm;
        form.EventEndWork();
      };
    }
  }
}