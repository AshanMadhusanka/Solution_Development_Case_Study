using System;
using System.Collections.Generic;

namespace InventoryControl.Models
{
    public partial class InventoryInfomation
    {
        public string InventId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int NuOfUnit { get; set; }
        public int ReOrderLevel { get; set; }
        public double UnitPrice { get; set; }
    }
}
