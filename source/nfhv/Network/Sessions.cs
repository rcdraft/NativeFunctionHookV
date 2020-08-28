using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeFunctionHookV.Network
{
    /// <summary>
    /// Network session and lobby related actions.
    /// It's here for collection purposes - do not actual use it otherwise you may banned.
    /// Some FiveM people may use it.
    /// </summary>
    public static class Sessions
    {
        /// <summary>
        /// Gets whether this player is the host of this session.
        /// </summary>
        public static bool IsHost
        {
            get => Function.Call<bool>(Hash.NETWORK_IS_HOST);
        }



        /// <summary>
        /// Ends the current session. It will kick all players out and reporting unknown error.
        /// </summary>
        public static void EndCurrentSession()
        {
            Function.Call(Hash.NETWORK_SESSION_END);
        }
    }
}
