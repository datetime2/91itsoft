﻿using System;
using System.Collections.Generic;

namespace ITsoft.Application.DTOs
{
    public class MenuDTO
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int SortOrder { get; set; }
        public DateTime Created { get; set; }
    }
}
