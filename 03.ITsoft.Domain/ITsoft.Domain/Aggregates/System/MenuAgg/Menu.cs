using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ITsoft.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITsoft.Domain.Aggregates
{
    [Table("Menu")]
    public class Menu : EntityBase
    {
        public override Guid Id { get; set; }
        [Required]
        public Guid ParentId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string Code { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        [DefaultValue(0)]
        public int SortOrder { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
