using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Purchase.Microservice.Model
{
    [Table("PurchaseDetails")]
    public class PurchaseDetails : BaseEntity
    {
        public Guid PurchaseMasterId { get; set; }
        public PurchaseMaster PurchaseMaster { get; set; }
        public Guid ProductId { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        [JsonIgnore]
        public decimal Amount { get; set; }
    }
}
