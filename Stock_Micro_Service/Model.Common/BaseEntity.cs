using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public Guid? UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

    }
}
