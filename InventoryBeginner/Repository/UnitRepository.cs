using InventoryBeginner.Data;
using InventoryBeginner.Interfaces;
using InventoryBeginner.Models;
namespace InventoryBeginner.Repository
{
    public class UnitRepository : IUnit
    {
        private readonly InventoryContext _context;

        public UnitRepository(InventoryContext context)
        {
            _context = context;
        }

        public Unit Create(Unit unit)
        {
            _context.Units.Add(unit);
            _context.SaveChanges();
            return unit;
        }

        public Unit Delete(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return unit;
        }

        public Unit Edit(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return unit;
        }

        public Unit GetUnit(int id)
        {
            return _context.Units.FirstOrDefault(u => u.Id == id);
        }

        public PaginatedList<Unit> GetItems(string sortProperty, Tools.SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Unit> units;
            if (SearchText != "")
                units = _context.Units.Where(u => u.Name.ToLower().Contains(SearchText.ToLower()) || u.Description.ToLower().Contains(SearchText.ToLower())).ToList();
            else
                units = _context.Units.ToList();

            units = DoSort(units, sortProperty, sortOrder);

            PaginatedList<Unit> resUnit = new PaginatedList<Unit>(units, pageIndex, pageSize);
            return resUnit;
        }
        private List<Unit> DoSort(List<Unit> units, string sortProperty, Tools.SortOrder sortOrder)
        {
            if (sortProperty.ToLower() == "name")
            {
                if (sortOrder == Tools.SortOrder.Ascending)
                    units = units.OrderBy(u => u.Name).ToList();
                else
                    units = units.OrderByDescending(u => u.Name).ToList();
            }
            else
            {
                if (sortOrder == Tools.SortOrder.Ascending)
                    units = units.OrderBy(u => u.Description).ToList();
                else
                    units = units.OrderByDescending(u => u.Description).ToList();
            }
            return units;
        }
    }
}
