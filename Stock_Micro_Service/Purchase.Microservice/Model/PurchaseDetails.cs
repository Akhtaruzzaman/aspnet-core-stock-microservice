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
        public Guid ProductId { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
