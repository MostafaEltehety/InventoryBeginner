using InventoryBeginner.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryBeginner.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }
        public virtual DbSet<Unit> Units { get; set; }

    }
}
