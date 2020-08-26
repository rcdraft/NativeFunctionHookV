using GTA;
using GTA.Math;
using GTA.Native;
using GTA.NaturalMotion;
using NativeFunctionHookV.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleSeat = NativeFunctionHookV.Enums.VehicleSeat;
using VehicleWindow = NativeFunctionHookV.Enums.VehicleWindow;

namespace NativeFunctionHookV
{
	/// <summary>
	/// Represents a vehicle.
	/// </summary>
	public class NVehicle : NEntity
	{
		/// <summary>
		/// Creates an instance of <see cref="NVehicle"/> from <see cref="Vehicle"/>.
		/// </summary>
		/// <param name="v"></param>
		public NVehicle(Vehicle v)
		{
			if (v == null || !v.Exists()) throw new ArgumentException("The vehicle is invalid.", new InvalidHandleableException(v));
			GVehicle = v;

		}

		public NVehicle(Model model, Vector3 position)
		{
			GVehicle = World.CreateVehicle(model, position);
		}

		public Vehicle GVehicle { get; private set; }

		/// <summary>
		/// Set whether play stall warning sounds when this instance are stalling or not.
		/// </summary>
		public bool EnableStallWarning
		{
			set
			{
				//if (GVehicle == null || !GVehicle.Exists()) throw new ArgumentException("The vehicle is invalid.", new InvalidHandleableException(this));
				
				CheckForExistsInternal();
				if (!Model.IsPlane) throw new InvalidOperationException("The specified vehicle was not a plane.");
				Function.Call(Hash.ENABLE_STALL_WARNING_SOUNDS, Handle, value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating how dirty is this instance.
		/// </summary>
		public float DirtLevel
		{
			get
			{
				CheckForExistsInternal();
				return Function.Call<float>(Hash.GET_VEHICLE_DIRT_LEVEL, Handle);
			}
			set
			{
				CheckForExistsInternal();
				Function.Call(Hash.SET_VEHICLE_DIRT_LEVEL, Handle, value);
			}
		}

		/// <summary>
		/// Gets or sets whether the siren of this instance is active.
		/// </summary>
		public bool IsSirenOn
		{
			get
			{
				CheckForExistsInternal();
				return Function.Call<bool>(Hash.IS_VEHICLE_SIREN_ON, Handle);
			}
			set
			{
				CheckForExistsInternal();
				Function.Call(Hash.SET_VEHICLE_SIREN, Handle, value);
			}
		}

		/// <summary>
		/// Gets or sets whether this instance is stolen.
		/// </summary>
		public bool IsStolen
		{
			get
			{
				CheckForExistsInternal();
				return Function.Call<bool>(Hash.IS_VEHICLE_STOLEN, Handle);
			}
			set
			{
				CheckForExistsInternal();
				Function.Call(Hash.SET_VEHICLE_IS_STOLEN, Handle, value);
			}
		}

		/// <summary>
		/// Gets or sets the engine health of this instance.
		/// </summary>
		/// <value>
		/// The engine health ranges between <c>0.0f</c> and <c>1000.0f</c>.
		/// <br />When the engine health is below <c>400.0f</c>, the engine will start to smoke.
		/// <br />When the engine health is <c>300.0f</c> or below, the car's back fire will become smokey and sound worse.
		/// <br />When the engine health is below <c>300.0f</c>, the car will have difficulties maintaining a stable acceleration.
		/// <br />When the engine health reaches <c>0.0f</c>, the car's engine will die.
		/// <br /><br /> from RAGE Plugin Hook docs.
		/// </value>
		public float EngineHealth
		{
			get
			{
				CheckForExistsInternal();
				return Function.Call<float>(Hash.GET_VEHICLE_ENGINE_HEALTH, Handle);
			}
			set
			{
				CheckForExistsInternal();
				Function.Call(Hash.SET_VEHICLE_ENGINE_HEALTH, Handle, value);
			}
		}

		/// <summary>
		/// Gets or sets the health of fuel tank of this instance.
		/// </summary>
		/// <value>
		/// The fuel tank health ranges between <c>0.0f</c> and <c>1000.0f</c>.
		/// <br />When the fuel tank health is below <c>700.0f</c>, fuel will start leaking.
		/// <br />When the fuel tank health is below <c>50.0f</c>, the engine will be unable to start.
		/// <br /><br /> from RAGE Plugin Hook docs.
		/// </value>
		public float FuelTankHealth
		{
			get
			{
				CheckForExistsInternal();
				return Function.Call<float>(Hash.GET_VEHICLE_PETROL_TANK_HEALTH, Handle);
			}
			set
			{
				CheckForExistsInternal();
				Function.Call(Hash.SET_VEHICLE_PETROL_TANK_HEALTH, Handle, value);
			}
		}

		/// <summary>
		/// Sets whether this instance needs to be hotwired to start.
		/// </summary>
		public bool NeedsToBeHotwired
		{
			set
			{
				CheckForExistsInternal();
				Function.Call(Hash.SET_VEHICLE_NEEDS_TO_BE_HOTWIRED, Handle, value);
			}
		}

		/// <summary>
		/// Sets whether the interior lights are on for this instance.
		/// </summary>
		public bool IsInteriorLightOn
		{
			set
			{
				CheckForExistsInternal();
				Function.Call(Hash.SET_VEHICLE_INTERIORLIGHT, Handle, value);
			}
		}

		/// <summary>
		/// Gets or sets whether engine of this instance is on.
		/// If you set it to <c>true</c> it will turn on instantly instead of driver turning on the engine.
		/// </summary>
		public bool IsEngineOn
        {
			get
            {
				CheckForExistsInternal();
				return Function.Call<bool>(Hash.GET_IS_VEHICLE_ENGINE_RUNNING, Handle);
            }
            set
            {
				CheckForExistsInternal();
				Function.Call(Hash.SET_VEHICLE_ENGINE_ON, Handle, value, false);
            }
        }

		/// <summary>
		/// Gets or sets whether this instance is available for drive.
		/// </summary>
		/// <value>
		/// Setting this property to <c>true</c> will disable this vehicle. Even if you turn it back on <c>false</c>,
		/// player will no longer be able to enter driver seat again.
		/// </value>
		public bool IsDriveable
        {
			get
            {
				CheckForExistsInternal();
				return Function.Call<bool>(Hash.IS_VEHICLE_DRIVEABLE, Handle);
            }
			set
            {
				CheckForExistsInternal();
				Function.Call(Hash.SET_VEHICLE_UNDRIVEABLE, Handle, !value);
            }
        }

		/// <summary>
		/// Rolls down specified window.
		/// </summary>
		/// <param name="window">The window wants to roll down.</param>
		public void RollDownWindow(VehicleWindow window)
		{
			if (GVehicle == null || !GVehicle.Exists()) throw new ArgumentException("The vehicle is invalid.", new InvalidHandleableException(this));
			Function.Call(Hash.ROLL_DOWN_WINDOW, Handle, (int)window);
		}

		/// <summary>
		/// Rolls up specified window.
		/// </summary>
		/// <param name="window">The window wants to roll up.</param>
		public void RollUpWindow(VehicleWindow window)
		{
			CheckForExistsInternal();
			Function.Call(Hash.ROLL_UP_WINDOW, Handle, (int)window);
		}

		/// <summary>
		/// Explode this instance instantaneously.
		/// </summary>
		public void Explode()
		{
			CheckForExistsInternal();
			Function.Call(Hash.EXPLODE_VEHICLE, Handle, true, false);
		}

		/// <summary>
		/// Washes this instance.
		/// </summary>
		public void Wash()
		{
			CheckForExistsInternal();
			DirtLevel = 0f;
		}

		/// <summary>
		/// Repairs this instance.
		/// </summary>
		public void Repair()
		{
			CheckForExistsInternal();
			Function.Call(Hash.SET_VEHICLE_FIXED, Handle);
		}

		/// <summary>
		/// Check whether the specified seat is available.
		/// </summary>
		/// <param name="seat">The seat to check.</param>
		/// <returns>Is the specified seat available.</returns>
		public bool IsSeatFree(VehicleSeat seat)
		{
			CheckForExistsInternal();
			return Function.Call<bool>(Hash.IS_VEHICLE_SEAT_FREE, Handle, seat);
		}
	}
}
