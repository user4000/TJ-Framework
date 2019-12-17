using Telerik.WinControls.UI;

namespace TJFramework
{
  internal class TJChildForm
  {
    internal RadForm ChildForm { get; private set; } = null;

    internal string PageName { get; } = string.Empty;

    internal string PageText { get; } = string.Empty;

    private TJChildForm(RadForm form, string pageName, string pageText)
    { /* Hidden constructor - you must create form only via FACTORY method */
      ChildForm = form;
      PageName = pageName;
      PageText = pageText;
    }

    internal static TJChildForm Create(RadForm form, string pageName, string pageText) => new TJChildForm(form, pageName, pageText);

    internal static TJChildForm Create<T>(string pageName, string pageText) where T : RadForm, new() => Create(new T(), pageName, pageText);

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
