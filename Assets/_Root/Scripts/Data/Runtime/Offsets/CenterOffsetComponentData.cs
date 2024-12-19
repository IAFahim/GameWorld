using Unity.Entities;
using Unity.Mathematics;

namespace _Root.Scripts.Data.Runtime.Offsets
{
    public struct CenterOffsetComponentData : IComponentData
    {
        public float3 Offset;
    }
}