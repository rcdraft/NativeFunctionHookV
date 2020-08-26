using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeFunctionHookV.Interfaces
{
    /// <summary>
    /// Represents an object can be deleted from game world.
    /// </summary>
    public interface IDeletable
    {
        void Delete();
    }
}
