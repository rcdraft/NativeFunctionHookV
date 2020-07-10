namespace NativeFunctionHookV.Enums
{
    /// <summary>
    /// Represents seat index.
    /// </summary>
    public enum VehicleSeat
    {
        /// <summary>
        /// The driver seat.
        /// </summary>
        Driver = -1,
        /// <summary>
        /// Next passenger seat available if possible.
        /// </summary>
        AnyPassengerAvailable = -2,
        /// <summary>
        /// Right Front seat, aka. Passenger / co-driver.
        /// </summary>
        RightFront = 0,
        /// <summary>
        /// Left Rear seat, aka. Passenger / Boot.
        /// </summary>
        LeftRear = 1,
        /// <summary>
        /// Right Rear seat, aka. Passenger / Boot.
        /// </summary>
        RightRear = 2
    }
}
