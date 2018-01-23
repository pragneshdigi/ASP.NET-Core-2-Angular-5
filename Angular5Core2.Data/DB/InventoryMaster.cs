using System;
using System.Collections.Generic;

namespace Angular5Core2.Data.DB
{
    public partial class InventoryMaster
    {
        public int InventoryId { get; set; }
        public string ItemName { get; set; }
        public int StockQty { get; set; }
        public int ReorderQty { get; set; }
        public int PriorityStatus { get; set; }
    }
}
