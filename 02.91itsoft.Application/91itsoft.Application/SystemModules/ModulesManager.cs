using _91itsoft.Application.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _91itsoft.Application.SystemModules
{
  public  class ModulesManager
    {
        private static List<Modules> _modules;
        private static readonly object LockObject = new object();
        private static void Init()
        {
            lock (LockObject)
            {
                _modules = new List<Modules>
                {
                    new Modules(ModuleType.UserSystem,
                        ModulesResource.UserSystem),

                    new Modules(ModuleType.BootstrapSamples,
                        ModulesResource.BootstrapSamples),

                    new Modules(ModuleType.AuthMenuSample,
                        ModulesResource.AuthMenuSample),
                };
            }
        }

        private ModulesManager()
        {
            Init();
        }

        private static ModulesManager _Instance;
        public static ModulesManager Instance
        {
            get { return _Instance ?? (_Instance = new ModulesManager()); }
        }

        public int GetModulesType(string typeStr)
        {
            ModuleType type;
            if (Enum.TryParse(typeStr, true, out type))
            {
                var m = _modules.FirstOrDefault(x => x.Type == type);
                if (m != null)
                {
                    return (int)m.Type;
                }
            }
            return 0;
        }

        public string GetModulesName(string typeStr)
        {
            ModuleType type;
            if (Enum.TryParse(typeStr, true, out type))
            {
                var m = _modules.FirstOrDefault(x => x.Type == type);
                if (m != null)
                {
                    return m.Name;
                }
            }
            return string.Empty;
        }
        public List<Modules> ListAll()
        {
            return _modules;
        }
        public string GetModulesName(ModuleType type)
        {
            var modules = _modules.FirstOrDefault(x => x.Type == type);
            if (modules == null)
                throw new ArgumentException(type.ToString(), "type");
            return modules.Name;
        }
    }
}
