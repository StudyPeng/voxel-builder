using World;

public class VoxelChunk
{
    public const int kSize = 33; // 2^5 cubes
    private Voxel[] _voxels = new Voxel[kSize * kSize * kSize];

    public Voxel GetVoxel(int x, int y, int z)
    {
        return _voxels[GetIndex(x, y, z)];
    }

    public void SetVoxel(int x, int y, int z, Voxel voxel)
    {
        _voxels[GetIndex(x, y, z)] = voxel;
    }
    
    private int GetIndex(int x, int y, int z)
    {
        return (x * kSize + y) * kSize + z;
    }
}
