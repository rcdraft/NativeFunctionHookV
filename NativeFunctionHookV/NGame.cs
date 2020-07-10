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
    /// Controls and alters, checks for general game behaivor.
    /// </summary>
    public static class NGame
    {
        /// <summary>
        /// Sets whether game should play ambient siren sound effect.
        /// </summary>
        public static bool PlayAmbientSirenEffect
        {
            set
            {
                // AUDIO::DISTANT_COP_CAR_SIRENS
                Function.Call(Hash._0x552369F549563AD5, value);
            }
        }

        /// <summary>
        /// Gets or sets whether player head is shown in pause menu.
        /// </summary>
        public static bool ShowPlayerHeadInPauseMenu
        {
            set => Function.Call(Hash._0x4EBB7E87AA0DBED4, value);
            get => Function.Call<bool>(Hash._0x9689123E3F213AA5);
        }

        /// <summary>
        /// Sets whether disables rockstar editor in current session.
        /// </summary>
        public static bool DisableRockstarEditor
        {
            set => Function.Call(Hash._0x9D8D44ADBBA61EF2, value);
        }

        /// <summary>
        /// Gets whether is player signed into Social Club or not. Beware, it related to social club.
        /// </summary>
        public static bool IsSignedIntoSocialClub => Function.Call<bool>(Hash.NETWORK_IS_SIGNED_IN);
    }
}
