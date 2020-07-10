using GTA;
using GTA.Math;
using GTA.Native;
using NativeFunctionHookV.Enums;
using NativeFunctionHookV.Helpers;
using System;

namespace NativeFunctionHookV
{
    public abstract class NEntity
    {
        #region Basic Implementations
        public Entity GEntity { get; private set; }
        public int Handle => GEntity.Handle;

        internal virtual void CheckForExistsInternal()
        {
            if(GEntity == null)
            {
                throw new NullReferenceException("The entity is null.");
            }

            if(!GEntity.Exists())
            {
                throw new InvalidHandleableException(this);
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// Sets whether this instance is glowing on glowing parts or not.
        /// </summary>
        public bool IsLightsEnabled
        {
            set
            {
                CheckForExistsInternal();
                Function.Call(Hash.SET_ENTITY_LIGHTS, Handle, value);
            }
        }


        /// <summary>
        /// Sets whether this instance is invincible.
        /// </summary>
        public bool IsInvincible
        {
            set
            {
                CheckForExistsInternal();
                Function.Call(Hash.SET_ENTITY_INVINCIBLE, Handle, value);
            }
        }

        /// <summary>
        /// Gets the model of this instance.
        /// </summary>
        public Model Model
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<Model>(Hash.GET_ENTITY_MODEL, Handle);
            }
        }

        /// <summary>
        /// Gets the type of this instance.
        /// </summary>
        public EntityType Type
        {
            get
            {
                CheckForExistsInternal();
                int result = Function.Call<int>(Hash.GET_ENTITY_TYPE, Handle);
                return (EntityType)result;
            }
        }

        /// <summary>
        /// Gets speed of this instance in meters per second.
        /// </summary>
        public float Speed
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<float>(Hash.GET_ENTITY_SPEED, Handle);
            }
        }

        /// <summary>
        /// Gets or sets the health of this instance.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if this property has been set to negative values.</exception>
        public int Health
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<int>(Hash.GET_ENTITY_HEALTH, Handle);
            }
            set
            {
                CheckForExistsInternal();
                if(value < 0)
                {
                    throw new InvalidOperationException("Health cannot set to below 0.");
                }
                Function.Call(Hash.SET_ENTITY_HEALTH, Handle, value, 0, 0);
            }
        }

        /// <summary>
        /// Get or sets the max health of this instance.
        /// </summary>
        public int MaxHealth
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<int>(Hash.GET_ENTITY_MAX_HEALTH, Handle);
            }
            set
            {
                CheckForExistsInternal();
                if (value < 0)
                {
                    throw new InvalidOperationException("Health cannot set to below 0.");
                }
                Function.Call(Hash.SET_ENTITY_MAX_HEALTH, Handle, value, 0);
            }
        }

        /// <summary>
        /// Gets whether this instance is dead.
        /// </summary>
        public bool IsDead
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<bool>(Hash.IS_ENTITY_DEAD, Handle, false);
            }
        }

        /// <summary>
        /// Gets whether this instance is in area that screen can display, ignoring obstacles.
        /// This means it will still <c>true</c> if this instance is behind obstacles such as walls as long as it is in screen 2D area.
        /// </summary>
        public bool IsOnScreen
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<bool>(Hash.IS_ENTITY_ON_SCREEN, Handle);
            }
        }

        /// <summary>
        /// Gets whether this instance is in water.
        /// </summary>
        public bool IsInWater
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<bool>(Hash.IS_ENTITY_IN_WATER, Handle);
            }
        }

        /// <summary>
        /// Gets whether this instance is in air.
        /// </summary>
        public bool IsInAir
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<bool>(Hash.IS_ENTITY_IN_AIR, Handle);
            }
        }

        /// <summary>
        /// Gets or sets whether this instance is persistent. Persistent entities will not removed by the game.
        /// <br /><b>Warning:</b> Setting this to <c>false</c> will make this instance go away like normal pedestrains if this instance is a ped. And also they will drive away it's last vehicle if possible.
        /// </summary>
        public bool IsPersistent
        {
            set
            {
                CheckForExistsInternal();
                if (value == true) Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Handle, false, false);
                else
                {
                    Function.Call(Hash.SET_ENTITY_AS_NO_LONGER_NEEDED, Handle);
                }
            }
        }

        /// <summary>
        /// Gets or sets the alpha of this instance. Alpha represents the transparency of a instance, it's value can be 0 - 255 (inclusive).
        /// </summary>
        public int Alpha
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<int>(Hash.GET_ENTITY_ALPHA, Handle);
            }
            set
            {
                CheckForExistsInternal();
                if(value <= -1)
                {
                    throw new ArgumentOutOfRangeException("The alpha cannot be a negative value.");
                }
                if(value > 255)
                {
                    throw new ArgumentOutOfRangeException("The alpha cannot be higher than 255.");
                }
                Function.Call(Hash.SET_ENTITY_ALPHA, Handle, value, false);
            }
        }

        /// <summary>
        /// Gets or sets current position of this instance.
        /// </summary>
        public Vector3 Position
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<Vector3>(Hash.GET_ENTITY_COORDS, Handle, !IsDead);
            }
            set
            {
                CheckForExistsInternal();
                Function.Call(Hash.SET_ENTITY_COORDS, Handle, value.X, value.Y, value.Z, 0, 0, 0, 1);
            }
        }

        /// <summary>
        /// Gets whether this entity is on fire.
        /// </summary>
        public bool IsOnFire
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<bool>(Hash.IS_ENTITY_ON_FIRE, Handle);
            }
        }

        public int Heading
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<int>(Hash.GET_ENTITY_HEADING, Handle);
            }
            set
            {
                CheckForExistsInternal();
                Function.Call(Hash.SET_ENTITY_HEADING, Handle);
            }
        }

        public float HeightAboveGround
        {
            get
            {
                CheckForExistsInternal();
                return Function.Call<float>(Hash.GET_ENTITY_HEIGHT_ABOVE_GROUND, Handle);
            }
        }

        /// <summary>
        /// Gets whether this instance is alive.
        /// </summary>
        /// <remarks>
        /// This API is only for convinence. It is simply <c>!IsDead</c>; it will be removed in further releases.
        /// </remarks>
        [Obsolete]
        public bool IsAlive => !IsDead;

        /// <summary>
        /// Gets the alpha of this instance.
        /// </summary>
        /// <remarks>
        /// This API is only for convinence. It simply redirects getter and setter to <see cref="Alpha"/>; it will be removed in further releases.
        /// </remarks>
        [Obsolete]
        public int Opacity
        {
            get => Alpha;
            set => Alpha = value;
        }


        #endregion
        #region Methods
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public virtual void Delete()
        {
            CheckForExistsInternal();
            GEntity.Delete();
        }

        /// <summary>
        /// Checks whether this instance valids.
        /// </summary>
        /// <returns>Does this instance valid.</returns>
        public bool IsValid()
        {
            return Function.Call<bool>(Hash.DOES_ENTITY_EXIST, Handle);
        }

        /// <summary>
        /// Checks if this instance has been damaged by other <see cref="NEntity"/> instance.
        /// </summary>
        /// <param name="other">Checks if it is damaged this instance.</param>
        /// <returns>Whether the other has damaged this instance.</returns>
        public virtual bool HasBeenDamagedBy(NEntity other)
        {
            CheckForExistsInternal();
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            other.CheckForExistsInternal();
            return Function.Call<bool>(Hash.HAS_ENTITY_BEEN_DAMAGED_BY_ENTITY, Handle, other.Handle);
        }

        /// <summary>
        /// Resets alpha of this instance.
        /// </summary>
        public void ResetAlpha()
        {
            CheckForExistsInternal();
            Function.Call(Hash.RESET_ENTITY_ALPHA, Handle);
        }

        #endregion
        #region Operators
        /// <summary>
        /// Returns handle of this instance and implicitly converts it to <see cref="InputArgument"/>.
        /// </summary>
        /// <param name="source">The instance itself.</param>
        public static implicit operator InputArgument(NEntity source)
        {
            if (source == null) throw new NullReferenceException();
            source.CheckForExistsInternal();

            return source.Handle;
        }

        /// <summary>
        /// Returns whether this instance is null or not valid.
        /// </summary>
        /// <param name="source">The instance itself.</param>
        public static implicit operator bool(NEntity source)
        {
            return source.Exists();
        }
        #endregion
    }
}
