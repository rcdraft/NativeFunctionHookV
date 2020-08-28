using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeFunctionHookV.Helpers
{
    /// <summary>
    /// Extension methods that allows developers to check for entity before calling them.
    /// </summary>
    public static class Safety
    {
        /// <summary>
        /// Checks whether this instance is null or not valid.
        /// </summary>
        /// <param name="instance">The instance itself.</param>
        /// <returns>Does this instance null or not exists.</returns>
        public static bool Exists(this NEntity instance) => !(instance == null || !instance.IsValid());
    }
}
