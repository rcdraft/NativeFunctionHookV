using GTA.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeFunctionHookV.Interfaces
{
    /// <summary>
    /// Represents an object has a position.
    /// </summary>
    public interface ISpatial
    {
        /// <summary>
        /// Gets or sets a value indicating heading of this instance.
        /// </summary>
        float Heading { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the position coordinate of this instance.
        /// </summary>
        Vector3 Position { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the current quaternion of this instance.
        /// </summary>
        Quaternion Quaternion { get; set; }
    }
}
