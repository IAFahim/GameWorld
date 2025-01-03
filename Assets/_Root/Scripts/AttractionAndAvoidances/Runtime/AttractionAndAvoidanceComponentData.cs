using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.AttractionAndAvoidances.Runtime
{
    [BurstCompile]
    public struct AttractionAndAvoidanceComponentData : IComponentData
    {
        public uint PhysicsCategoryTagAdd1;
        public uint PhysicsCategoryTagAdd2;
        public short MainEntityPriority;

        [BurstCompile]
        public int GetModPriority(uint physicsCategoryTags)
        {
            int totalPriority = 0;
            if ((physicsCategoryTags & PhysicsCategoryTagAdd1) == 1) totalPriority += 1;
            if ((physicsCategoryTags & PhysicsCategoryTagAdd2) == 1) totalPriority += 2;
            return totalPriority;
        }
    }
}