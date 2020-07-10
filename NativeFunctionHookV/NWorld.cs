using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeFunctionHookV
{
    /// <summary>
    /// Controls behavior of all entities of the world or the generic world.
    /// </summary>
    public static class NWorld
    {
        /// <summary>
        /// Sets whether pedestrians sound their horn longer, faster and more agressive when they use their horn.
        /// </summary>
        public static bool AggressiveHorn
        {
            set
            {
                Function.Call(Hash.SET_AGGRESSIVE_HORNS, value);
            }
        }

        /// <summary>
        /// Prepares alarm. Automatic called when <see cref="StartAlarm(string name)"/> is called.
        /// </summary>
        /// <param name="name">The name of that alarm.</param>
        public static void PrepareAlarm(string name)
        {
            Function.Call(Hash.PREPARE_ALARM, name);
        }

        /// <summary>
        /// Starts alarm.
        /// </summary>
        /// <param name="name">The name of that alarm.</param>
        /// <param name="p1">Unknown. Seems like to control duration, or from prepare alarm native.</param>
        public static void StartAlarm(string name, bool p1 = false)
        {
            PrepareAlarm(name);
            Function.Call(Hash.START_ALARM, name, p1);
        }
    }
}
