using System.ComponentModel.DataAnnotations;

namespace InventoryBeginner.Models
{
    public enum SetOrder { Ascending = 0, Descending = 1 }
    public class Unit
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(75)]
        public string Description { get; set; }
    }
}
