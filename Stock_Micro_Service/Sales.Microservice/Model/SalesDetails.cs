using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Microservice.Model
{
    [Table("SalesDetails")]
    public class SalesDetails : BaseEntity
    {
        public Guid product_id { get; set; }
        public decimal qty { get; set; }
        public decimal unit_price { get; set; }
        public decimal amount { get; set; }
    }
}
