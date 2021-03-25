using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sales.Microservice.Model
{
    [Table("SalesMaster")]
    public class SalesMaster : BaseEntity
    {
        public string VoucherNo { get; set; }
        public string Remarks { get; set; }
        public Guid CustomerId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
    }
}
