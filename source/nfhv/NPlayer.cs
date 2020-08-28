using GTA;
using GTA.Native;
using NativeFunctionHookV.Helpers;
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
        /// <summary>
        /// Creates <see cref="NPlayer"/> instance from GTA Player.
        /// </summary>
        /// <param name="gtaPlayer">The GTA Player.</param>
        public NPlayer(Player gtaPlayer)
        {
            Id = gtaPlayer.Handle;
        }

        /// <summary>
        /// Creates <see cref="NPlayer"/> instance from ID.
        /// </summary>
        /// <param name="id">Player ID. Can write 0 if you are in story mode.</param>
        public NPlayer(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the handle of this player.
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// Gets current stealth noice of player.
        /// </summary>
        public float CurrentStealthNoice => Function.Call<float>(Hash.GET_PLAYER_CURRENT_STEALTH_NOISE, Id);

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
            get => Function.Call<int>(Hash.GET_FAKE_WANTED_LEVEL);
            set => Function.Call(Hash.SET_FAKE_WANTED_LEVEL, value);
        }

        /// <summary>
        /// Sets whether this player has chat restrections in online.
        /// </summary>
        public bool ChatRestrections
        {
            set => Function.Call(Hash.NETWORK_OVERRIDE_CHAT_RESTRICTIONS, Id, value);
        }

        /// <summary>
        /// Gets or sets whether this player has been concealed in online.
        /// </summary>
        public bool IsConcealed
        {
            get => Function.Call<bool>(Hash.NETWORK_IS_PLAYER_CONCEALED, Id);
            set => Function.Call(Hash.NETWORK_CONCEAL_PLAYER, Id, true);
        }

        /// <summary>
        /// Gets the name of this instance.
        /// </summary>
        public string Name => Function.Call<string>(Hash.GET_PLAYER_NAME, Id);

        /// <summary>
        /// Gets the character of this instance.
        /// </summary>
        public NPed Character
        {
            get
            {
                Ped p = Function.Call<Ped>(Hash.GET_PLAYER_PED, Id);
                return new NPed(p);
            }
        }

        /// <summary>
        /// Gets or sets the model of this instance.
        /// If you set model for this player, the previous ped acquired from <see cref="Character"/> will become invalid.
        /// </summary>
        /// <remarks>
        /// What setter actually do is deletes the current <see cref="Character"/> <see cref="NPed"/> and create a new one
        /// for the player, with given model.
        /// </remarks>
        public Model Model
        {
            get => Character.Model;
            set => Function.Call(Hash.SET_PLAYER_MODEL, Id, value);
        }

        /// <summary>
        /// Gets a value indicating whether this player is pressing horn.
        /// </summary>
        public bool IsPressingHorn => Function.Call<bool>(Hash.IS_PLAYER_PRESSING_HORN, Id);

        /// <summary>
        /// Gets or sets whether this player is invincible.
        /// </summary>
        public bool IsInvincible
        {
            get => Function.Call<bool>(Hash.GET_PLAYER_INVINCIBLE, Id);
            set => Function.Call(Hash.SET_PLAYER_INVINCIBLE, Id, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this player is ignored by police.
        /// </summary>
        public bool IsIgnoredByPolice
        {
            set => Function.Call(Hash.SET_POLICE_IGNORE_PLAYER, Id, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this player is ignored by every NPCs.
        /// </summary>
        public bool IsIgnoredByEveryone
        {
            set => Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Id, value);
        }

        /// <summary>
        /// Gets a value indicating whether this player is dead.
        /// </summary>
        public bool IsDead
        {
            get => Function.Call<bool>(Hash.IS_PLAYER_DEAD, Id);
        }

        public bool IsFreeAiming
        {
            get => Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING_AT_ENTITY, Id);
        }

        public int TimeSincePlayerLastHitAnyVehicle
        {
            get => Function.Call<int>(Hash.GET_TIME_SINCE_PLAYER_HIT_VEHICLE, Id);
        }

        public int TimeSincePlayerLastHitAnyPed
        {
            get => Function.Call<int>(Hash.GET_TIME_SINCE_PLAYER_HIT_PED, Id);
        }

        /// <summary>
        /// Gets whether this player is available to play.
        /// </summary>
        /// <value>
        /// Checks for whether this player has a <see cref="NPed"/>, the ped is valid, and it is not dead or arrested.
        /// </value>
        public bool IsPlaying
        {
            get => Function.Call<bool>(Hash.IS_PLAYER_PLAYING, Id);
        }

        /// <summary>
        /// Gets or sets the current wanted level of this instance.
        /// </summary>
        public int WantedLevel
        {
            get => Function.Call<int>(Hash.GET_PLAYER_WANTED_LEVEL, Id);
            set
            {
                Function.Call(Hash.SET_PLAYER_WANTED_LEVEL, Id, value, false);
                Function.Call(Hash.SET_PLAYER_WANTED_LEVEL_NOW, Id, false);
            }
        }

        /// <summary>
        /// Sets whether this instance can use any covers.
        /// </summary>
        public bool CanUseCover
        {
            set => Function.Call(Hash.SET_PLAYER_CAN_USE_COVER, Id, value);
        }

        /// <summary>
        /// Sets whether to dispatch cops to player representd by this instance when player is wanted.
        /// It will not work on any wanted level in progress.
        /// </summary>
        public bool DispatchCops
        {
            set => Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, Id, value);
        }

        /// <summary>
        /// Sets whether this instance can control it's character.
        /// </summary>
        public bool HasControl
        {
            set => Function.Call(Hash.SET_PLAYER_CONTROL, Id, value);
        }

        /// <summary>
        /// Gets whether this instance is targetting at any entity.
        /// </summary>
        /// <param name="entity">The entity to check.</param>
        /// <returns>Whether it's targetted.</returns>
        public bool IsFreeAimingAtEntity(NEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (!entity.IsValid()) throw new InvalidHandleableException(entity);
            return Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING_AT_ENTITY, Id, entity);
        }
    }
}
