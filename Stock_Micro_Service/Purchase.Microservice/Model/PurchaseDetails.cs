using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Purchase.Microservice.Model
{
    [Table("PurchaseDetails")]
    public class PurchaseDetails : BaseEntity
    {
        public Guid product_id { get; set; }
        public decimal qty { get; set; }
        public decimal unit_price { get; set; }
        public decimal amount { get; set; }
    }
}
