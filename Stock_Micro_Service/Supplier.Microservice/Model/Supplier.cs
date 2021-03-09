using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier.Microservice.Model
{
    [Table("Supplier")]
    public class Supplier:BaseEntity
    {
        public string name { get; set; }
        public string address { get; set; }
        public string mobile { get; set; }
    }
}
