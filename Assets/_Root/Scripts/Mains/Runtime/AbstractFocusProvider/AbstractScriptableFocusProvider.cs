using _Root.Scripts.Mains.Runtime.References;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Mains.Runtime.AbstractFocusProvider
{
    public abstract class AbstractScriptableFocusProvider : ScriptableObject
    {
        public bool isFocusActive;
        public abstract void Change(ref SystemState state, MainEntityReferenceSingletonComponentData mainEntityReference);
        public abstract void Tick(ref SystemState state, MainEntityReferenceSingletonComponentData mainEntityReference);
        public abstract void Forget();
    }
}