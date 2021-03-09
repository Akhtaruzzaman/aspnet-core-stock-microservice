using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Model
{
    [Table("Customer")]
    public class Customer:BaseEntity
    {
        public string name { get; set; }
        public string address { get; set; }
        public string mobile { get; set; }
    }
}
