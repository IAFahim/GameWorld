using System.Collections.Generic;
using _Root.Scripts.Mains.Runtime.AbstractFocusProvider;
using Pancake;
using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEditor;
using UnityEngine;

namespace _Root.Scripts.Mains.Runtime.References
{
    [CreateAssetMenu(fileName = "ScriptableMainReferenceMiddlewareSingleton",
        menuName = "Scriptable/MainReferenceMiddlewareSingleton", order = 256)]
    public class
        ScriptableMainReferenceMiddlewareSingleton : ScriptableSettings<ScriptableMainReferenceMiddlewareSingleton>
    {
        [SerializeField] private AbstractScriptableFocusProvider[] scriptableFocusProviders;

        [ShowInInspector, ReadOnly] private bool _live;
        private readonly List<int> _activeIndexes = new();


        public void Process(ref SystemState state, MainEntityReferenceSingletonComponentData mainEntityReference)
        {
            bool changedThisFrame = mainEntityReference.IsChangedThisFrame;

            if (mainEntityReference.IsPresent)
            {
                if (_activeIndexes.Count == 0) GetActiveIndex(ref state, mainEntityReference, changedThisFrame);
                if (_activeIndexes.Count == 0) return;
                foreach (var activeIndex in _activeIndexes)
                {
                    scriptableFocusProviders[activeIndex].Tick(ref state, mainEntityReference);
                }

                if (changedThisFrame)
                {
                    _live = true;
                    ClearOthers(_activeIndexes);
                }
            }
            else ClearAll(changedThisFrame, _activeIndexes);
        }

        private void ClearOthers(List<int> activeIndexes)
        {
            for (var i = 0; i < scriptableFocusProviders.Length; i++)
            {
                if (activeIndexes.Contains(i)) continue;
                var scriptableFocusProvider = scriptableFocusProviders[i];
                Forget(scriptableFocusProvider);
            }
        }

        private void ClearAll(bool changedThisFrame, List<int> activeIndexes)
        {
            if (changedThisFrame)
            {
                _live = false;
                ForgetActive();
                activeIndexes.Clear();
            }
        }

        private void GetActiveIndex(ref SystemState state,
            MainEntityReferenceSingletonComponentData mainEntityReference,
            bool changedThisFrame)
        {
            _live = true;
            int modIndex = mainEntityReference.Mod;
            int index = 0;
            while (modIndex > 0)
            {
                if ((modIndex & 1) == 0) continue;
                if (index > scriptableFocusProviders.Length) break;
                if (changedThisFrame)
                {
                    scriptableFocusProviders[index].Change(ref state, mainEntityReference);
                    scriptableFocusProviders[index].isFocusActive = true;
                    _activeIndexes.Add(index);
                }
                modIndex >>= 1;
                index++;
            }
        }

        private void ForgetActive()
        {
            foreach (var scriptableModInputManger in scriptableFocusProviders) Forget(scriptableModInputManger);
        }

        private static void Forget(AbstractScriptableFocusProvider scriptableModInputManger)
        {
            if (!scriptableModInputManger.isFocusActive) return;
            scriptableModInputManger.Forget();
            scriptableModInputManger.isFocusActive = false;
        }

        private void OnEnable()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= EditorApplicationOnplayModeStateChanged;
            EditorApplication.playModeStateChanged += EditorApplicationOnplayModeStateChanged;
#endif
        }

#if UNITY_EDITOR
        private void EditorApplicationOnplayModeStateChanged(PlayModeStateChange obj)
        {
            if (obj == PlayModeStateChange.ExitingPlayMode)
            {
                if (_live) ForgetActive();
                _live = false;
                _activeIndexes.Clear();
            }
        }
#endif

        private void OnDisable()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= EditorApplicationOnplayModeStateChanged;
#endif
        }
    }
}