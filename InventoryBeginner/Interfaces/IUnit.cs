using InventoryBeginner.Models;

namespace InventoryBeginner.Interfaces
{
    public interface IUnit
    {
        PaginatedList<Unit> GetItems(string sortProperty, Tools.SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5);
        Unit GetUnit(int id);
        Unit Create(Unit unit);
        Unit Edit(Unit unit);
        Unit Delete(Unit unit);
    }
}
