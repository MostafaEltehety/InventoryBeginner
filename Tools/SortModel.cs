namespace InventoryBeginner.Tools
{
    public enum SortOrder { Ascending = 0, Descending = 1 }
    public class SortModel
    {
        private string UpIcon = "bi bi-arrow-up-circle";
        private string DownIcon = "bi bi-arrow-down-circle";
        public string SortedProperty { get; set; }
        public SortOrder SortedOrder { get; set; }
        public string SortedExpresion { get; private set; }

        private List<SortableColumns> sortableColumns = new List<SortableColumns>();

        public void AddColumn(string colName, bool IsDefaultIcon = false)
        {
            SortableColumns tmp = this.sortableColumns.Where(c => c.ColumnName.ToLower() == colName.ToLower()).SingleOrDefault();
            if (tmp == null)
                sortableColumns.Add(new SortableColumns() { ColumnName = colName });
            if (IsDefaultIcon == true || sortableColumns.Count == 1)
            {
                SortedProperty = colName;
                SortedOrder = SortOrder.Ascending;
            }
        }
        public SortableColumns GetColumn(string colName)
        {
            SortableColumns tmp = this.sortableColumns.Where(c => c.ColumnName.ToLower() == colName.ToLower()).SingleOrDefault();
            if (tmp == null)
                sortableColumns.Add(new SortableColumns() { ColumnName = colName });
            return tmp;
        }

        public void ApplySort(string sortExpresion)
        {
            if (sortExpresion == null)
                sortExpresion = "";

            if (sortExpresion == "")
                sortExpresion = this.SortedProperty;

            SortedExpresion = sortExpresion.ToLower();
            foreach (SortableColumns sortableColumns in this.sortableColumns)
            {
                sortableColumns.SortIcon = "";
                sortableColumns.SortExpresion = sortableColumns.ColumnName;

                if (sortExpresion == sortableColumns.ColumnName.ToLower())
                {
                    this.SortedOrder = SortOrder.Ascending;
                    this.SortedProperty = sortableColumns.ColumnName;
                    sortableColumns.SortIcon = DownIcon;
                    sortableColumns.SortExpresion = sortableColumns.ColumnName + "_desc";
                }
                if (sortExpresion == sortableColumns.ColumnName.ToLower() + "_desc")
                {
                    this.SortedOrder = SortOrder.Descending;
                    this.SortedProperty = sortableColumns.ColumnName;
                    sortableColumns.SortIcon = UpIcon;
                    sortableColumns.SortExpresion = sortableColumns.ColumnName;
                }

            }


        }

    }
    public class SortableColumns
    {
        public string ColumnName { get; set; }
        public string SortExpresion { get; set; }
        public string SortIcon { get; set; }
    }
}
