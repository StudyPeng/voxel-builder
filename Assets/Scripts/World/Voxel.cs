using System;

namespace World
{
    [Flags]
    public enum VoxelType : int
    {
        EMPTY = 0b0000_0000,
        SOIL = 0b0000_0001,
        WATER = 0b0000_0010,
    }

    [Flags]
    public enum Density : int
    {
        EMPTY = 0b0000_0000, // 0
        FULL = 0b1111_1111, // 256
        v0 = 0b0000_0001, // 1
        v1 = 0b0000_0010, // 2
        v2 = 0b0000_0100, // 4
        v3 = 0b0000_1000, // 8
        v4 = 0b0001_0000, // 16
        v5 = 0b0010_0000, // 32
        v6 = 0b0100_0000, // 64
        v7 = 0b1000_0000, // 128
    }

    public struct Voxel
    {
        public VoxelType Type;
        public float Density;

        public Voxel(VoxelType t, float d)
        {
            Type = t;
            Density = d;
        }
    }
}