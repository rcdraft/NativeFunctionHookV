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
    /// Represents a player. A player can be anything from a player.
    /// </summary>
    public class NPlayer
    {
        public NPlayer()
        {
            GPlayer = Game.Player;
        }

        /// <summary>
        /// The player.
        /// </summary>
        public Player GPlayer { get; set; }

        /// <summary>
        /// Gets current stealth noice of player.
        /// </summary>
        public float CurrentStealthNoice => Function.Call<float>(Hash.GET_PLAYER_CURRENT_STEALTH_NOISE, GPlayer);

        /// <summary>
        /// Gets or sets the fake wanted level of player.
        /// </summary>
        /// <remarks>
        /// A fake wanted level will override real wanted level behaviors. As of it's name, it only affects HUD and does not
        /// affect any actual game behaviors, for example, any peds has cop model or has been set to cop will not react to player
        /// and no peds in police cars will respond to player.
        /// </remarks>
        public int FakeWantedLevel 
        {
            get => Function.Call<int>(Hash._0x4C9296CBCD1B971E);
            set => Function.Call<int>(Hash.SET_FAKE_WANTED_LEVEL, value);
        }
    }
}
