using Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Purchase.Microservice.Model
{
    [Table("PurchaseMaster")]
    public class PurchaseMaster : BaseEntity
    {
        public string VoucherNo { get; set; }
        public string Remarks { get; set; }
        public Guid SupplierId { get; set; }
        [JsonIgnore]
        public Supplier Supplier { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }
    }
}
