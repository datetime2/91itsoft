﻿using System;

namespace ITsoft.Application.DTOs
{
    public class RoleDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SortOrder { get; set; }

        public bool? IsEnable { get; set; }

        public DateTime Created { get; set; }
    }
}
