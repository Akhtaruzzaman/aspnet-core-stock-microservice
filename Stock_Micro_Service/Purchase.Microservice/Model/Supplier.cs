using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Purchase.Microservice.Model
{
    [Table("Supplier")]
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
    }
}
