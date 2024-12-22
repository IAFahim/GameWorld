using Unity.Entities;

namespace _Root.Scripts.Data.Runtime.Selecteds
{
    public struct SelectedComponentData : IComponentData, IEnableableComponent
    {
        public bool UnFocusEmptyClicked;
        public float TimeSceneEnabled;
    }
}