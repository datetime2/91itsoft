using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ITsoft.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITsoft.Domain.Aggregates
{
    [Table("Role")]
    public class Role : EntityBase
    {
        public override Guid Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [DefaultValue(0)]
        public int SortOrder { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
