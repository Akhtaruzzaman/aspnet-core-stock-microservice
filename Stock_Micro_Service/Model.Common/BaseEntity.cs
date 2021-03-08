using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
