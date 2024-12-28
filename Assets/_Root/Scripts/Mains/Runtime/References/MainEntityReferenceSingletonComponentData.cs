using Unity.Entities;

namespace _Root.Scripts.Mains.Runtime.References
{
    public struct MainEntityReferenceSingletonComponentData : IComponentData
    {
        public Entity MainEntities;
        public int StackOrder;
    }
}