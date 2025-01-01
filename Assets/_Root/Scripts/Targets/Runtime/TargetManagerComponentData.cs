using BovineLabs.Core.ObjectManagement;
using Unity.Entities;

namespace _Root.Scripts.Targets.Runtime
{
    public struct TargetManagerComponentData : IComponentData
    {
        public ETarget Target;
    }
}