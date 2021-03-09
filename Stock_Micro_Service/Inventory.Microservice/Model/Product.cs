using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Microservice.Model
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        public string name { get; set; }
        public string unit { get; set; }
        public string sku { get; set; }
        public decimal purchase_price { get; set; }
        public decimal sales_price { get; set; }
    }
}
