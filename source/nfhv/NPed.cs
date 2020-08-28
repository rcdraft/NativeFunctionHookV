using GTA;
using GTA.Math;
using GTA.Native;
using NativeFunctionHookV.Enums;
using NativeFunctionHookV.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeFunctionHookV
{
    /// <summary>
    /// Represents a ped. Ped represents any of Characters in the game world, such as the player character, animals, pedestrians, police officers, soldiers, gangs, etc.
    /// </summary>
    public class NPed : NEntity
    {
        /// <summary>
        /// Initializes an instance of <see cref="NPed"/> from existing Ped.
        /// </summary>
        /// <param name="p">The existing ped.</param>
        /// <exception cref="InvalidHandleableException">Thrown when the ped does not exists.</exception>
        public NPed(Ped p)
        {
            if(p == null || !p.Exists())
            {
                throw new InvalidHandleableException(p);
            }
            GPed = p;
        }

        /// <summary>
        /// Initializes an instance of <see cref="NPed"/> with a random model.
        /// </summary>
        /// <param name="position"></param>
        public NPed(Vector3 position)
        {
            GPed = World.CreateRandomPed(position);
        }

        /// <summary>
        /// Initializes an instance of <see cref="NPed"/> by creating a Ped with specified model and bind it to <see cref="GPed"/>.
        /// </summary>
        /// <param name="model"></param>
        public NPed(Model model, Vector3 position)
        {
            GPed = World.CreatePed(model, position);
        }

        /// <summary>
        /// The ped. Used as an fallback.
        /// </summary>
        public Ped GPed { get; private set; }

        /// <summary>
        /// Set infinite ammo to specified weapon on specified ped.
        /// </summary>
        /// <param name="weapon">The weapon wants to set infinite weapon.</param>
        /// <exception cref="InvalidHandleableException">Thrown when the ped does not exists.</exception>
        public void InfiniteAmmo(WeaponHash weapon)
        {
            CheckForExists();
            Function.Call(Hash.SET_PED_INFINITE_AMMO, Handle, true, (int)weapon);
        }

        /// <summary>
        /// Sets whether this ped has infinite ammo in clip of any weapon or not.
        /// </summary>
        /// <exception cref="InvalidHandleableException">Thrown when the ped does not exists.</exception>
        public bool InfiniteAmmoClip
        {
            set
            {
                CheckForExists();
                Function.Call(Hash.SET_PED_INFINITE_AMMO_CLIP, Handle, value);
            }
        }

        private void CheckForExists()
        {
            if (GPed == null || !GPed.Exists())
            {
                throw new InvalidHandleableException(this);
            }
        }


        /// <summary>
        /// Gets the time of death of this ped.
        /// </summary>
        /// <exception cref="InvalidHandleableException">Thrown when the ped does not exists.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the ped was not died yet.</exception>
        public TimeSpan TimeOfDeath
        {
            get
            {
                CheckForExists();
                if (!GPed.IsDead) throw new InvalidOperationException("This ped is not died yet.");
                int time = Function.Call<int>(Hash.GET_PED_TIME_OF_DEATH, GPed);
                int ticksSinceDeath = Game.GameTime - time;
                TimeSpan result = TimeSpan.FromMilliseconds(ticksSinceDeath);
                return result;
            }
        }

        public bool IsPlayer
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_A_PLAYER, Handle);
            }
        }

        /// <summary>
        /// Sets whether is this pinned down by a group of enimies or not.
        /// </summary>
        /// <exception cref="InvalidHandleableException">Thrown when the ped does not exists.</exception>
        public bool IsPinnedDown
        {
            set
            {
                CheckForExists();
                Function.Call(Hash.SET_PED_PINNED_DOWN, Handle, value, -1);
            }
        }

        /// <summary>
        /// Gets whether the entity is in stealth mode.
        /// </summary>
        /// <exception cref="InvalidHandleableException">Thrown when the ped does not exists.</exception>
        public bool IsInStealthMovement
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.GET_PED_STEALTH_MOVEMENT, Handle);
            }
        }

        /// <summary>
        /// Sets whether this ped will get out of a rolled over vehicle or not.
        /// </summary>
        /// <exception cref="InvalidHandleableException">Thrown when the ped does not exists.</exception>
        public bool AllowEscapeRolledVehicle
        {
            set
            {
                CheckForExists();
                Function.Call(Hash.SET_PED_GET_OUT_UPSIDE_DOWN_VEHICLE, Handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the awareness of a event of this ped.
        /// </summary>
        /// <exception cref="InvalidHandleableException">Thrown when the ped does not exists.</exception>
        /// <exception cref="InvalidOperationException">Thrown when setter is called for setting to <see cref="PedAwareness.InvalidHandleable"/>.</exception>
        public PedAwareness Awareness
        {
            get
            {
                CheckForExists();
                return (PedAwareness)Function.Call<int>(Hash.GET_PED_ALERTNESS, Handle);
            }
            set
            {
                CheckForExists();
                if (value == PedAwareness.InvalidHandleable) throw new InvalidOperationException("This value cannot be used.");
                Function.Call(Hash.SET_PED_ALERTNESS, Handle, (int)value);
            }
        }

        /// <summary>
        /// Gets whether the ped is in progress of a writhe because of a sudden gunshot wounds, regardless of current health.
        /// </summary>
        /// <exception cref="InvalidHandleableException">Thrown when the ped does not exists.</exception>
        public bool IsInWrithe
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_IN_WRITHE, Handle);
            }
        }

        /// <summary>
        /// Gets whether the ped can hear player or not.
        /// </summary>
        /// <exception cref="InvalidHandleableException">Thrown when the ped does not exists.</exception>
        public bool CanHeardPlayer
        { 
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.CAN_PED_HEAR_PLAYER, Game.Player, Handle);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is stopped.
        /// </summary>
        public bool IsStopped
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_STOPPED, Handle);
            }
        }


        /// <summary>
        /// Gets a value indicating whether this instance is sitting in any vehicle.
        /// </summary>
        public bool IsInAnyVehicle
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_VEHICLE, Handle);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is sitting in a police vehicle.
        /// </summary>
        public bool IsInAnyPoliceVehicle
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_POLICE_VEHICLE, Handle);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is sitting in any boat.
        /// </summary>
        public bool IsInAnyBoat
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_BOAT, Handle);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is sitting in any submarine.
        /// </summary>
        public bool IsInAnySubmarine
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_SUB, Handle);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is sitting in any helicopter.
        /// </summary>
        public bool IsInAnyHelicopter
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_HELI, Handle);
            }
        }

        public bool IsInAnyPlane
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_PLANE, Handle);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is sitting on a bike.
        /// </summary>
        public bool IsOnAnyBike
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_ON_ANY_BIKE, Handle);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating current armor that this instance has.
        /// </summary>
        public int Armor
        {
            get
            {
                CheckForExists();
                return Function.Call<int>(Hash.GET_PED_ARMOUR, Handle);
            }
            set
            {
                CheckForExists();
                Function.Call(Hash.SET_PED_ARMOUR, Handle, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is humanoid.
        /// </summary>
        public bool IsHuman
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_HUMAN, Handle);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance <strong>on</strong> top of any vehicle.
        /// </summary>
        /// <remarks>
        /// Original native name is IS_PED_<strong>ON</strong>_VEHICLE.
        /// </remarks>
        public bool IsOnTopOfAnyVehicle
        {
            get
            {
                CheckForExists();
                return Function.Call<bool>(Hash.IS_PED_ON_VEHICLE, Handle);
            }
        }

        /// <summary>
        /// Gets the last vehicle entered of this instance.
        /// </summary>
        public NVehicle LastVehicle
        {
            get
            {
                CheckForExists();
                Vehicle v = Function.Call<Vehicle>(Hash.GET_VEHICLE_PED_IS_IN, Handle, true);
                if (v != null || v.Exists()) return new NVehicle(v);
                else return null;
            }
        }

        /// <summary>
        /// Gets the current vehicle of this instance.
        /// </summary>
        public NVehicle CurrentVehicle
        {
            get
            {
                CheckForExists();
                Vehicle v = Function.Call<Vehicle>(Hash.GET_VEHICLE_PED_IS_IN, Handle, false);
                if (v != null || v.Exists()) return new NVehicle(v);
                else return null;
            }
        }

        /// <summary>
        /// Increases <see cref="Armor"/> amount that this instance has.
        /// </summary>
        /// <param name="increase">The value to increase.</param>
        public void IncreaseArmor(int increase)
        {
            CheckForExists();
            Function.Call(Hash.ADD_ARMOUR_TO_PED, Handle, increase);
        }

        /// <summary>
        /// Determines whether this instance is in specified vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        /// <returns>Whether this instance is in that vehicle.</returns>
        public bool IsInVehicle(NVehicle vehicle)
        {
            CheckForExists();
            if(vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }
            if (!vehicle.IsValid()) throw new ArgumentException("Specified vehicle does not exists.", new InvalidHandleableException(vehicle));
            return Function.Call<bool>(Hash.IS_PED_IN_VEHICLE, Handle, vehicle);
        }

        /// <summary>
        /// Determines whether this instance is on top of specified vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        /// <returns>Whether this instance is on top of that vehicle.</returns>
        public bool IsOnTopOfVehicle(NVehicle vehicle)
        {
            CheckForExists();
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }
            if (!vehicle.IsValid()) throw new ArgumentException("Specified vehicle does not exists.", new InvalidHandleableException(vehicle));
            return Function.Call<bool>(Hash.IS_PED_ON_VEHICLE, Handle, vehicle);
        }

        #region Shortcuts to GTA Ped
        /// <summary>
        /// Tasks of a ped. Task represents actions that a ped will preform. If you want preform tasks in sequence, check out <see cref="TaskSequence"/>.
        /// </summary>
        public TaskInvoker Tasks => GPed.Task;
    }
}
#endregion