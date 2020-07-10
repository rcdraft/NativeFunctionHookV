namespace NativeFunctionHookV.Enums
{
    /// <summary>
    /// Awareness of events of a ped.
    /// </summary>
    public enum PedAwareness
    {
        /// <summary>
        /// Returns this value when specified ped does not exists. Do not use this value
        /// when accessing setter, it only returned by getter rarely because getter will throw a
        /// <see cref="InvalidHandleableException"/> if this ped does not exists before preforming the
        /// actual check.
        /// </summary>
        InvalidHandleable = -1,
        /// <summary>
        /// Ped has not aware of any event.
        /// </summary>
        NotAware = 0,
        /// <summary>
        /// Ped heard a event, such as gun shots, etc.
        /// </summary>
        Heard,
        /// <summary>
        /// Ped knows this event, for example, origin of a event.
        /// </summary>
        Knows,
        /// <summary>
        /// Ped has fully alerted by event.
        /// </summary>
        Alerted
    }
}
