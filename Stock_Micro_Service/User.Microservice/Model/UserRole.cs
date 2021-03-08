using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Microservice.Model
{
    [Table("UserRole")]
    public class UserRole : BaseEntity
    {
        public Guid UsersId { get; set; }
        public virtual Users Users { get; set; }
        public int Sn { get; set; }
    }
}
