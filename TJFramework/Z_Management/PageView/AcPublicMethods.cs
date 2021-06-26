using System.Drawing;
using TJFramework.Form;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Collections.Generic;

namespace TJFramework
{
  public partial class TJPageView
  {
    public RadPageViewPage GetPageByUniqueName(string pageUniqueName)
    {
      foreach (RadPageViewPage page in MainPageView.Pages) if (page.Name == pageUniqueName) return (page); return null;
    }

    public string GetUniquePageName<T>() where T : RadForm
    {
      string PageName = string.Empty;
      TJChildForm childForm = null;

      foreach (KeyValuePair<string, TJChildForm> entry in DictionaryChildForms)
      {
        childForm = entry.Value;
        if (childForm != null)
          if (childForm.ChildForm is T)
          {
            PageName = entry.Key; break;
          }
      }
      return PageName;
    }

    public string GetUniquePageName(string FormTypeName)
    {
      string PageName = string.Empty;
      TJChildForm childForm = null;

      foreach (KeyValuePair<string, TJChildForm> entry in DictionaryChildForms)
      {
        childForm = entry.Value;
        if (childForm != null)
          if (childForm.ChildForm.GetType().FullName == FormTypeName)
          {
            PageName = entry.Key; break;
          }
      }
      return PageName;
    }

    public bool IsPageSelected(string pageUniqueName)
    {
      if (PageExists(pageUniqueName) == false) return false;
      return (MainPageView.SelectedPage == GetPageByUniqueName(pageUniqueName));
    }

    public bool IsPageSelected<T>() where T : RadForm
    {
      return IsPageSelected(GetUniquePageName<T>());
    }

    public void GotoPage(string pageUniqueName)
    {
      if (PageExists(pageUniqueName))
      {
        RadPageViewPage page = GetPageByUniqueName(pageUniqueName);
        if (page != null) MainPageView.SelectedPage = page;
      }
    }

    public void GotoPage<T>() where T : RadForm
    {
      string PageName = GetUniquePageName<T>(); GotoPage(PageName);
    }

    public void EnableTab(string pageUniqueName, bool Enable)
    {
      if (PageExists(pageUniqueName))
      {
        RadPageViewPage page = GetPageByUniqueName(pageUniqueName);
        if ((page != null) && (page.Item.Enabled != Enable)) page.Item.Enabled = Enable;
      }
    }

    public void EnableTab<T>(bool Enable) where T : RadForm
    {
      string PageName = GetUniquePageName<T>(); EnableTab(PageName, Enable);
    }


    public void EnablePage(string pageUniqueName, bool Enable)
    {
      if (PageExists(pageUniqueName))
      {
        RadPageViewPage page = GetPageByUniqueName(pageUniqueName);
        if ((page != null) && (page.Enabled != Enable)) page.Enabled = Enable;
      }
    }

    public void EnablePage<T>(bool Enable) where T : RadForm
    {
      string PageName = GetUniquePageName<T>(); EnablePage(PageName, Enable);
    }

    public void ShowPage(string pageUniqueName, bool Visible)
    {
      if (PageExists(pageUniqueName))
      {
        RadPageViewPage page = GetPageByUniqueName(pageUniqueName);
        if (page != null) page.Item.Visibility = Visible ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;
      }
    }

    public void ShowPage<T>(bool Show) where T : RadForm
    {
      string PageName = GetUniquePageName<T>(); ShowPage(PageName, Show);
    }

    public T GetRadForm<T>() where T : RadForm
    {
      T radForm = null;
      TJChildForm childForm = null;

      foreach (KeyValuePair<string, TJChildForm> entry in DictionaryChildForms)
      {
        childForm = entry.Value;
        if (childForm != null)
          if (childForm.ChildForm is T)
          {
            try { radForm = (T)childForm.ChildForm; } catch { };
            break;
          }
      }
      return radForm;
    }
  }
}