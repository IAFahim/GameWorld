using Unity.Entities;

namespace _Root.Scripts.Mains.Runtime.References
{
    public struct MainEntityReferenceSingletonComponentData : IComponentData
    {
        public Entity MainEntity;
        public bool IsPresent;
        public bool IsChangedThisFrame;
        public int StackOrder;
        public int Mod;
        public int Id;
    }
}