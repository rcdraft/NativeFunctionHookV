using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeFunctionHookV.Native
{
    /// <summary>
    /// DLC and DLC2 namespaces.
    /// </summary>
    public static class DLC
    {
        public static bool IS_DLC_PRESENT(uint hash) => Function.Call<bool>(Hash.IS_DLC_PRESENT, hash);
        public static bool GET_IS_LOADING_SCREEN_ACTIVE() => Function.Call<bool>(Hash.GET_IS_LOADING_SCREEN_ACTIVE);
        public static void _LOAD_MP_DLC_MAPS() => Function.Call(Hash._LOAD_MP_DLC_MAPS);
        public static void _UNLOAD_MP_DLC_MAPS() => Function.Call(Hash._LOAD_SP_DLC_MAPS);
    }
}
