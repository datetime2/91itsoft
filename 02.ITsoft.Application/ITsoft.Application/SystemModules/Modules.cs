using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITsoft.Application.SystemModules
{
    public enum ModuleType
    {
        UserSystem = 1,
        BootstrapSamples = 2,
        AuthMenuSample = 3,
    }
    public class Modules
    {
        public Modules(ModuleType type, string name)
        {
            Type = type;
            Name = name;
        }
        public ModuleType Type { get; set; }
        public string Name { get; set; }
    }
}
