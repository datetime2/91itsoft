﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITsoft.Application.Exceptions
{
    public class DefinedException: Exception
    {
        public DefinedException(string message)
            : base(message)
        {
        }
    }
}
