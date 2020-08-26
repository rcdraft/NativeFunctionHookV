using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeFunctionHookV.Interfaces
{
    public interface IHandleable
    {
        int Handle { get; }
        bool IsValid();
    }
}
