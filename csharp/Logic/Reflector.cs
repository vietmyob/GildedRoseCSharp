using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using csharp.Interface;

namespace csharp.Logic
{
    public class Reflector
    {
        private readonly IEnumerable<Type> _IUpdaterClass;

        public Reflector()
        {
            _IUpdaterClass = from type in Assembly.GetExecutingAssembly().GetTypes()
                where typeof(IUpdater).IsAssignableFrom(type)
                select type;
        }
        public Type GetIUpdaterClassType(string className)
        {
            return _IUpdaterClass.FirstOrDefault(x => string.Compare(x.Name, className, StringComparison.InvariantCulture) == 0);
        }
    }
}