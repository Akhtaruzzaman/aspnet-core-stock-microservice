using Model.Common;
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
        public string voucher_no { get; set; }
        public string remarks { get; set; }
        public Guid supplier_id { get; set; }
    }
}
