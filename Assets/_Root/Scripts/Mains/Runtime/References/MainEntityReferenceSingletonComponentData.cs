using Unity.Entities;

namespace _Root.Scripts.Mains.Runtime.References
{
    public struct MainEntityReferenceSingletonComponentData : IComponentData
    {
        public Entity MainEntity;
        public int StackOrder;
    }
}