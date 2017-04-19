using System;

namespace _91itsoft.Application.DTOs
{
    public class RoleDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SortOrder { get; set; }

        public DateTime Created { get; set; }

        public Guid RoleGroupId { get; set; }
    }
}
