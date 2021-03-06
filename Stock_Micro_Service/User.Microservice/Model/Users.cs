using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Authentication.Microservice.Model
{
    [Table("Users")]
    public class Users : BaseEntity
    {
        public string name { get; set; }
        public string email { get; set; }
        [JsonIgnore]
        public string password { get; set; }
        [NotMapped]
        public int TotalRole { get; set; }
    }
}
