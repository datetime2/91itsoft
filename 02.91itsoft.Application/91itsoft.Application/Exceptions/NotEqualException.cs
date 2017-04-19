using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _91itsoft.Application.Exceptions
{
    public class NotEqualException : Exception
    {
        public NotEqualException(string message)
            : base(message)
        {
        }
    }
}
