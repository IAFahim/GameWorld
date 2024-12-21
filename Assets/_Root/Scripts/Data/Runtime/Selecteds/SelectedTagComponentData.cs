using Unity.Entities;

namespace _Root.Scripts.Data.Runtime.Selecteds
{
    public struct SelectedTagComponentData : IComponentData, IEnableableComponent
    {
        public bool EnabledThisFrame;
    }
}