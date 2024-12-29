using Unity.Entities;
using Unity.Mathematics;

namespace _Root.Scripts.Directions.Runtime
{
    public struct DirectionComponentData : IComponentData
    {
        public float3 Direction;
    }
}