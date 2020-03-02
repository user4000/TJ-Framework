using System.Data;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using TJFramework.Extensions;

namespace TJFramework.Standard
{
  internal abstract class TJGridWithDataTable : TJGridManager // Действия с объектом который представлен в табличном виде. Содержит RadGridView связанный с DataTable //
  {
    internal BindingSource DataBindingSource { get; } = new BindingSource();

    internal DataTable Table { get; set; } = new DataTable();

    internal TJGridWithDataTable() { } // Constructor //

    internal void SetDataSourceForGrid() => Grid.DataSource = DataBindingSource;

    internal delegate Task TypeDelegateEventDataColumnChanging(object sender, DataColumnChangeEventArgs e);

    private TypeDelegateEventDataColumnChanging DelegateEventDataColumnChanging { get; set; } = null;

    protected bool DelegateEventDataColumnChangingEnabled { get; set; } = true;

    internal override void InitializeGrid(RadGridView grid, bool SetAnotherTheme = false) // Called from User Form Constructor //
    {
      base.InitializeGrid(grid, SetAnotherTheme);
      DataBindingSource.DataSource = Table;
      SetDataSourceForGrid();
      //Table.ColumnChanging += async (s, e) => await EventDataColumnChanging(s, e);
    }

    internal void SetEventDataColumnChanging(TypeDelegateEventDataColumnChanging method)
    {
      DelegateEventDataColumnChanging = method;
    }

    protected async Task EventDataColumnChanging(object sender, DataColumnChangeEventArgs e)
    { // Событие: Пользователь закончил редактирование содержимого ячейки //
      string CurrentColumnName = e.Column.ColumnName;
      string CurrentCellValue = e.Row[CurrentColumnName].ToString();
      string ProposedCellValue = e.ZzProposedValue();

      //MessageBox.Show($"{CurrentColumnName}---{CurrentCellValue}---{ProposedCellValue}","EventDataColumnChanging");
      //ms.Debug( $"{CurrentColumnName}---{CurrentCellValue}---{ProposedCellValue}", "EventDataColumnChanging");

      if ( // if column cannot be empty we return old value //
          (ProposedCellValue.Trim().Length < 1) &&
          (ColumnCannotBeEmpty(CurrentColumnName))
         )
        e.ProposedValue = CurrentCellValue;

      if ( (DelegateEventDataColumnChanging != null) && DelegateEventDataColumnChangingEnabled ) await DelegateEventDataColumnChanging.Invoke(sender, e);
    }

    internal string GetValue(CurrentRowChangedEventArgs e, string FieldName)
    {
      string s = string.Empty;
      try { s = e.CurrentRow.Cells[TJStandard.GetGridColumnName(FieldName)].Value.ToString(); } catch { s = string.Empty; }
      return s;
    }

    internal void UpdateOneCell(string KeyField, string KeyValue, string FieldName, string FieldValue)
    {
      DataRow row = Table.ZzFindRowByKey(KeyField, KeyValue);
      if (row != null)
      {
        DelegateEventDataColumnChangingEnabled = false;
        row[FieldName] = FieldValue;
        DelegateEventDataColumnChangingEnabled = true;
      }
    }

    internal void EventEndWork() // Событие, которое вызывается клиентом при подготовке выхода из программы //
    {
      DelegateEventDataColumnChanging = null;
      Grid.ZzDispose();
      Table.Clear();
      Table.Columns.Clear();
      Table.Dispose();
    }
  }
}
