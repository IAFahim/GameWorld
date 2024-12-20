using Unity.Entities;

namespace _Root.Scripts.Data.Runtime.Waters
{
    public struct WaterInfoComponentData : IComponentData
    {
        public float WaterHeight;
        public float AngularDamping;
        public float StabilizationTorque;
    }
}