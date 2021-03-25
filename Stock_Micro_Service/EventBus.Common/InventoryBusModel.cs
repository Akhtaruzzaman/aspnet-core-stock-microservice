using System;

namespace EventBus.Common
{
    public class InventoryBusModel
    {
        public Guid ProductId { get; set; }
        public decimal in_qty { get; set; }
        public decimal out_qty { get; set; }
        public string remarks { get; set; }
        public Guid createdBy { get; set; }
    }
    public class InventoryBusMessage
    {
        public string Name { get; set; }
    }
}
