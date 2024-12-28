using Unity.Entities;

namespace _Root.Scripts.Mains.Runtime
{
    public struct MainEntityStackTagComponentData : IComponentData, IEnableableComponent
    {
        public int StackOrder;
    }
}