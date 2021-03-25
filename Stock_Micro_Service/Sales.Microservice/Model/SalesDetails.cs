using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sales.Microservice.Model
{
    [Table("SalesDetails")]
    public class SalesDetails : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid SalesMasterId { get; set; }
        public virtual SalesMaster SalesMaster { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        [JsonIgnore]
        public decimal Amount { get; set; }
    }
}
