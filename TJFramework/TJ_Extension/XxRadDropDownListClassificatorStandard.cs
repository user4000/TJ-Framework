using System;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TJFramework.Standard;

namespace TJFramework.Extensions
{
  public static class XxRadDropDownListClassificatorStandard
  {
    private static void EventDropDownListKeyUp(object sender, KeyEventArgs e)
    {
      if (sender is RadDropDownList == false) return;
      RadDropDownList DList = sender as RadDropDownList;
      if (DList.Popup.IsDisplayed == false) return;

      if (DList.Text.Trim() == string.Empty) { DList.FilterExpression = ""; return; }
      DList.FilterExpression = $"{nameof(MxSimpleEntity.NameObject)} LIKE '%{DList.Text}%'";
    }

    public static void ZzSetClassificatorStandardVisualStyle(this RadDropDownList DDList, SizingMode mode = SizingMode.None)
    {
      DDList.DropDownStyle = RadDropDownStyle.DropDown;
      DDList.DropDownListElement.ListElement.Font = DDList.Font;
      DDList.DropDownSizingMode = mode;
      DDList.AutoCompleteMode = AutoCompleteMode.None;
      DDList.KeyUp += new KeyEventHandler(EventDropDownListKeyUp);
      DDList.TextChanged += new EventHandler(EventTextChanged);
    }

    private static void EventTextChanged(object sender, EventArgs e)
    {
      if (sender is RadDropDownList == false) return;
      RadDropDownList DList = sender as RadDropDownList;
      if (DList.FindStringExact(DList.Text) < 0) DList.SelectedIndex = 0;
    }
  }
}