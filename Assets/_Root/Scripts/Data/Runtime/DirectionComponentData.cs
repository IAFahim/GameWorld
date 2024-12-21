using Unity.Entities;
using Unity.Mathematics;

namespace _Root.Scripts.Data.Runtime
{
    public struct DirectionComponentData : IComponentData
    {
        public float3 Direction;
    }
}