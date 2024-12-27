using Unity.Entities;

namespace _Root.Scripts.Selects.Runtime
{
    public struct SelectedComponentData : IComponentData, IEnableableComponent
    {
        public int SelectionOrder;
        public bool UnFocusEmptyClicked;
        public float TimeSceneEnabled;
    }
}