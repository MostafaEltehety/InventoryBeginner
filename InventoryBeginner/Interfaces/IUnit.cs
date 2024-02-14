using InventoryBeginner.Models;

namespace InventoryBeginner.Interfaces
{
    public interface IUnit
    {
        List<Unit> GetUnits();
        Unit GetUnit(int id);
        Unit Create(Unit unit);
        Unit Edit(Unit unit);
        Unit Delete(Unit unit);
    }
}
