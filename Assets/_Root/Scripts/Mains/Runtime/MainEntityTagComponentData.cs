using Unity.Entities;

namespace _Root.Scripts.Mains.Runtime
{
    public struct MainEntityTagComponentData : IComponentData, IEnableableComponent
    {
        public int StackOrder;
    }
}