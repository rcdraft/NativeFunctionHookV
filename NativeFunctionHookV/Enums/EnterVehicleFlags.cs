namespace NativeFunctionHookV.Enums
{
    /// <summary>
    /// Represents how the entity gets into a vehicle.
    /// </summary>
    public enum EnterVehicleFlags
    {
        None,
        Normal,
        WarpToDoor,
        WarpIntoVehicle,
        AllowJacking = 8,
        WarpDirectlyIntoVehicle = 16,
        EnterFromOppositeSide = 262144,
        OnlyOpenDoor = 524288
    }
}