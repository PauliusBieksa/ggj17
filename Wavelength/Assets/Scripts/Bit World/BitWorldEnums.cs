﻿public enum Wavelength
{
    Infrared = 0,
    Visible = 1,
    Ultraviolet = 2,
    IV = 3,
    IU = 4,
    VU = 5,
    IVU = 6
};

public enum BitType
{
    Void,
    Air,
    Wall,
    ColWall,
    BeaconBL,
    BeaconBR,
    BeaconTL,
    BeaconTR,
    Upgrade,
    Spawn,
    Portal
};

public enum Direction
{
    up = 0,
    right = 1,
    down = 2,
    left = 3
};

public enum WaveColour
{
    I = 0xFF0000,
    V = 0xFFFF00,
    U = 0xFF00FF,
    IV = 0xFF8000,
    IU = 0xBF0062,
    VU = 0x00FFFF,
    IVU = 0xFFFFFF
};

public enum WallShape
{
    x0,
    x1,
    x2,
    x3,
    x4,
    x12,
    x13,
    x14,
    x23,
    x24,
    x34,
    x123,
    x124,
    x134,
    x234,
    x1234
};
