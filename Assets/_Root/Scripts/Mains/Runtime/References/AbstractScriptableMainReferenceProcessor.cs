using UnityEngine;

namespace _Root.Scripts.Mains.Runtime.References
{
    public abstract class AbstractScriptableMainReferenceProcessor : ScriptableObject
    {
        public bool isModActive;
        public abstract void Set(MainEntityReferenceSingletonComponentData mainEntityReference);
        public abstract void Tick(MainEntityReferenceSingletonComponentData mainEntityReference);
        public abstract void Forget();
    }
}