
using GTA;
using GTA.Native;
using NativeFunctionHookV.Enums;
using System;
using VehicleSeat = NativeFunctionHookV.Enums.VehicleSeat;

namespace NativeFunctionHookV.Entities
{
    public class NTaskInvoker
    {
        public NTaskInvoker(NPed p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            p.CheckForExistsInternal();
            Ped = p;
        }

        public NPed Ped { get; private set; }

        private void CheckForExistsInternal()
        {
            if (Ped == null) throw new NullReferenceException("Ped given was null.");
            Ped.CheckForExistsInternal();
        }

        /// <summary>
        /// Makes <see cref="Ped"/> stand still in specified time.
        /// </summary>
        /// <param name="time">Time of stand still. In milliseconds.</param>
        public void StandStill(int time)
        {
            CheckForExistsInternal();
            Function.Call(Hash.TASK_STAND_STILL, Ped.Handle, time);
        }

        /// <summary>
        /// Makes <see cref="Ped"/> hands up in specified time.
        /// </summary>
        /// <param name="time">Duration of hands up. In milliseconds.</param>
        public void HandsUp(int time)
        {
            InternalHandsUp(time, -1);
        }

        /// <summary>
        /// Makes <see cref="Ped"/> hands up and face specified ped.
        /// </summary>
        /// <param name="time">Duration of hands up. In milliseconds.</param>
        /// <param name="ped">The ped to face to.</param>
        public void HandsUp(int time, NPed ped)
        {
            InternalHandsUp(time, ped.Handle);
        }

        private void InternalHandsUp(int time, int facePed)
        {
            CheckForExistsInternal();
            Function.Call(Hash.TASK_HANDS_UP, Ped, time, facePed, -1, false);
        }

        public void EnterVehicle(NVehicle vehicle, VehicleSeat seat, int timeout = -1, bool run = false, GTA.EnterVehicleFlags flags = GTA.EnterVehicleFlags.None)
        {

        }


    }
}
