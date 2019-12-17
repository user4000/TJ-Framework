using Telerik.WinControls.UI;

namespace TJFramework
{
  public static class XxGridViewRowInfo
  {
    public static string ZzGetCellValue(this GridViewRowInfo row, string FieldName) => row.Cells[TJStandard.GetGridColumnName(FieldName)].Value.ToString();
  }
}

