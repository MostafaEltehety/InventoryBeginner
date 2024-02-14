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

        public List<Unit> GetUnits()
        {
            return _context.Units.ToList();
        }
    }
}
