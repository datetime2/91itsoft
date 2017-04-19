﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _91itsoft.Application.Exceptions
{
    /// <summary>
    /// 参数不能为空
    /// </summary>
    public class ArgumentEmptyException : DefinedException
    {
        public ArgumentEmptyException(string message)
            : base(message)
        {
            
        }
    }
}
