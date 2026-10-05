using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using World.MarchingCube;

namespace World
{
    public class World : MonoBehaviour
    {
        public int CubeSize = 32;
        public float VoxelDensity = 1.0f;
        public float IsometricDensity = 0.5f;
        
        private int VoxelSize;
        private VoxelChunk _voxelChunk;
        
        private MeshFilter _mesh;
        private MeshRenderer _meshRenderer;
        private MeshCollider _meshCollider;
        private NativeArray<float3> _vertices;
        private NativeArray<float3> _normals;
        private NativeArray<int> _triangles;

        private void Awake()
        {
            VoxelSize = CubeSize + 1;
            _voxelChunk = new VoxelChunk();
            _mesh = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshCollider = GetComponent<MeshCollider>();

            if (_mesh == null)
            {
                transform.AddComponent<MeshFilter>();
            }

            if (_meshRenderer == null)
            {
                transform.AddComponent<MeshRenderer>();
            }

            if (_meshCollider == null)
            {
                transform.AddComponent<MeshCollider>();
            }
        }

        private void Start()
        {
            for (int x = 0; x < VoxelSize; x++)
            {
                for (int y = 0; y < VoxelSize; y++)
                {
                    for (int z = 0; z < VoxelSize; z++)
                    {
                        if (y == VoxelSize - 1)
                        {
                            _voxelChunk.SetVoxel(x, y, z, new Voxel(VoxelType.EMPTY, 0.0f));
                        }
                        else
                        {
                            _voxelChunk.SetVoxel(x, y, z, new Voxel(VoxelType.SOIL, 1.0f));
                        }
                    }
                }
            }
        }

        private void Update()
        {
            WorldTick();
        }

        private void LateUpdate()
        {
        }

        private void WorldTick()
        {
            for (int x = 0; x < CubeSize; x++)
            {
                for (int y = 0; y < CubeSize; y++)
                {
                    for (int z = 0; z < CubeSize; z++)
                    {
                        float d0 = _voxelChunk.GetVoxel(x, y, z).Density;
                        float d1 = _voxelChunk.GetVoxel(x + 1, y, z).Density;
                        float d2 = _voxelChunk.GetVoxel(x + 1, y + 1, z).Density;
                        float d3 = _voxelChunk.GetVoxel(x, y + 1, z).Density;
                        float d4 = _voxelChunk.GetVoxel(x, y, z + 1).Density;
                        float d5 = _voxelChunk.GetVoxel(x + 1, y, z + 1).Density;
                        float d6 = _voxelChunk.GetVoxel(x + 1, y + 1, z + 1).Density;
                        float d7 = _voxelChunk.GetVoxel(x, y + 1, z + 1).Density;

                        int cubeBit = 0;
                        if (d0 < IsometricDensity) cubeBit |= (int)Density.v0;
                        if (d1 < IsometricDensity) cubeBit |= (int)Density.v1;
                        if (d2 < IsometricDensity) cubeBit |= (int)Density.v2;
                        if (d3 < IsometricDensity) cubeBit |= (int)Density.v3;
                        if (d4 < IsometricDensity) cubeBit |= (int)Density.v4;
                        if (d5 < IsometricDensity) cubeBit |= (int)Density.v5;
                        if (d6 < IsometricDensity) cubeBit |= (int)Density.v6;
                        if (d7 < IsometricDensity) cubeBit |= (int)Density.v7;
                        
                        int edge = WorldTable.Edge_Mask[cubeBit];
                    }
                }
            }
        }
    }
}