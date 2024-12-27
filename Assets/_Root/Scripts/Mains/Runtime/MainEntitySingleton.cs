using Unity.Collections;
using Unity.Entities;

namespace _Root.Scripts.Mains.Runtime
{
    public struct MainEntitySingleton : IComponentData
    {
        public NativeList<Entity> MainEntities;
    }
}