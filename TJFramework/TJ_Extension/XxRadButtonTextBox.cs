using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TJFramework.Extensions
{
  public static class XxRadButtonTextBox 
  {
    public static void ZzRemoveButtonBorder(this RadButtonTextBox control)
    {
      foreach (var item in control.RightButtonItems)
      {
        if (item is RadButtonElement) (item as RadButtonElement).ShowBorder = false;
      }
      foreach (var item in control.LeftButtonItems)
      {
        if (item is RadButtonElement) (item as RadButtonElement).ShowBorder = false;
      }
    }

    public static void ZzOpenFolderHandler(this RadButtonTextBox control, bool ReadOnly, bool RightButton, Action ActionFolderSelected)
    {
      RadItemOwnerCollection collection = RightButton ? control.RightButtonItems : control.LeftButtonItems;
      foreach (var item in collection)
      {
        if (item is RadButtonElement)
        {
          RadButtonElement button = item as RadButtonElement;
          button.Click += async (sender, e) => await EventOpenFolderClick(control, button, e);
          button.Tag = ActionFolderSelected;
          control.ReadOnly = ReadOnly;
          break;
        }
      }
    }

    public static void ZzOpenFileHandler(this RadButtonTextBox control, bool ReadOnly, bool RightButton, Action ActionFileSelected)
    {
      RadItemOwnerCollection collection = RightButton ? control.RightButtonItems : control.LeftButtonItems;
      foreach (var item in collection)
      {
        if (item is RadButtonElement)
        {
          RadButtonElement button = item as RadButtonElement;
          button.Click += async (sender, e) => await EventOpenFileClick(control, button, e);
          button.Tag = ActionFileSelected;
          control.ReadOnly = ReadOnly;
          break;
        }
      }
    }

    private static void ZzRightButtonClick(this RadButtonTextBox control, EventHandler handler)
    {
      if (handler == null) return;
      foreach (var item in control.RightButtonItems)
      {
        if (item is RadButtonElement) (item as RadButtonElement).Click += handler; break;
      }
    }

    private static void ZzLeftButtonClick(this RadButtonTextBox control, EventHandler handler)
    {
      if (handler == null) return;
      foreach (var item in control.LeftButtonItems)
      {
        if (item is RadButtonElement) (item as RadButtonElement).Click += handler; break;
      }
    }

    private static async Task<bool> EventOpenFolderClick(RadButtonTextBox control, RadButtonElement button, EventArgs e)
    {
      RadButtonTextBox textbox = control;
      RadOpenFolderDialog dialog = new RadOpenFolderDialog();

      button.Visibility = ElementVisibility.Collapsed;

      dialog.MultiSelect = false;
      dialog.ShowHiddenFiles = false;
      dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

      string PreviousFolder = textbox.Text;

      if (String.IsNullOrWhiteSpace(PreviousFolder) == false)
        if (Directory.Exists(PreviousFolder))
        {
          dialog.InitialDirectory = PreviousFolder;
        }

      DialogResult result = dialog.ShowDialog();
      if (result == DialogResult.OK)
      {
        textbox.Text = dialog.FileName;       
        if (button.Tag is Action) (button.Tag as Action).Invoke();
      }

      await Task.Delay(1000);
      button.Visibility = ElementVisibility.Visible;
      return true;
    }

    private static async Task<bool> EventOpenFileClick(RadButtonTextBox control, RadButtonElement button, EventArgs e)
    {
      RadButtonTextBox textbox = control;
      RadOpenFileDialog dialog = new RadOpenFileDialog();

      button.Visibility = ElementVisibility.Collapsed;

      dialog.MultiSelect = false;
      dialog.ShowHiddenFiles = false;
      dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

      string PreviousValue = textbox.Text;

      if (String.IsNullOrWhiteSpace(PreviousValue) == false)
        if (File.Exists(PreviousValue))
        {
          dialog.InitialDirectory = Path.GetDirectoryName(PreviousValue);
        }

      DialogResult result = dialog.ShowDialog();
      if (result == DialogResult.OK)
      {
        textbox.Text = dialog.FileName;
        if (button.Tag is Action) (button.Tag as Action).Invoke();
      }

      await Task.Delay(1000);
      button.Visibility = ElementVisibility.Visible;
      return true;
    }
  }
}
