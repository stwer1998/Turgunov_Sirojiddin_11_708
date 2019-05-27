using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Entities
{
    public interface ICanCheck
    {
        bool Check(MethodInfo targetMethod, object[] args);
    }
}
