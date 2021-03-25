using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Inventory.Microservice.Model
{
    [Table("Stock")]
    public class Stock: BaseEntity
    {
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public decimal in_qty { get; set; }
        public decimal out_qty { get; set; }
        public decimal balance_qty { get; set; }
        public string remarks { get; set; }
    }
}
