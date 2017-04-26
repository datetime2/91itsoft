using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITsoft.PlatSystem.Helper
{
    public interface IServiceResolver
    {
        T Resolve<T>();
        object Resolve(Type type);
    }
}