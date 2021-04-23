using System;

namespace Battle_Ship_Game
{
    public enum SpotStatus
    {
        Empty,
        Ship,
        Miss,
        Hit,
        Sunk
    }

    public enum ShotStatus
    {
        InValid,
        Valid,
        Unique,
        Miss,
        Hit,
        Sunk
    }
}