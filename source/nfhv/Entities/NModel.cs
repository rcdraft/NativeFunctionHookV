using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeFunctionHookV.Entities
{
    public class NModel
    {
        public NModel(int hash)
        {
            Hash = hash;
        }

        public NModel(string name)
        {
            Hash = NGame.GetHashKey(name);
        }

        public int Hash { get; set; }

        
    }
}
