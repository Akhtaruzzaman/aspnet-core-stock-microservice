using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Microservice.Model
{
    [Table("SalesMaster")]
    public class SalesMaster : BaseEntity
    {
        public string voucher_no { get; set; }
        public string remarks { get; set; }
        public Guid customer_id { get; set; }
    }
}
