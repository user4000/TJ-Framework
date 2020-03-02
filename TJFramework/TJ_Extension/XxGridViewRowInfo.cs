using Telerik.WinControls.UI;
using TJFramework.Standard;

namespace TJFramework.Extensions
{
  public static class XxGridViewRowInfo
  {
    public static string ZzGetCellValue(this GridViewRowInfo row, string FieldName) => row.Cells[TJStandard.GetGridColumnName(FieldName)].Value.ToString();
  }
}

