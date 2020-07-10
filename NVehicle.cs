using GTA;
using GTA.Math;
using GTA.Native;
using GTA.NaturalMotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeFunctionHookV
{
    /// <summary>
    /// Represents a vehicle.
    /// </summary>
    public class NVehicle
    {
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

        public int Handle => GVehicle.Handle;

        /// <summary>
        /// Set whether play stall warning sounds when stalling or not.
        /// </summary>
        public bool EnableStallWarning
        {
            set
            {
                if (GVehicle == null || !GVehicle.Exists()) throw new ArgumentException("The vehicle is invalid.", new InvalidHandleableException(this));
                if (!GVehicle.Model.IsPlane) throw new InvalidOperationException("The specified vehicle was not a plane.");
                Function.Call(Hash._0xC15907D667F7CFB2, Handle, value);
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

        public void RollUpDown(VehicleWindow window)
        {
            if (GVehicle == null || !GVehicle.Exists()) throw new ArgumentException("The vehicle is invalid.", new InvalidHandleableException(this));
            Function.Call(Hash.ROLL_UP_WINDOW, Handle, (int)window);
        }
    }
}
