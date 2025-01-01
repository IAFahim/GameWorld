using BovineLabs.Core.ObjectManagement;
using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.AttractionAndAvoidances.Runtime
{
    [BurstCompile]
    public struct AttractionAndAvoidanceComponentData : IComponentData
    {
        public int MainEntityPriority;
        [ObjectCategories] public int Mod1;
        [ObjectCategories] public int Mod2;
        [ObjectCategories] public int Mod3;

        [BurstCompile]
        public int GetModPriority(int mod)
        {
            int totalPriority = 0;
            if ((Mod1 & mod) == 1) totalPriority += 1;
            if ((Mod2 & mod) == 1) totalPriority += 2;
            if ((Mod3 & mod) == 1) totalPriority += 3;
            return totalPriority;
        }
    }
}