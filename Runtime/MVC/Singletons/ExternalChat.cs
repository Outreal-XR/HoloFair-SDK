using System;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod.Runtime
{
    public class ExternalChat : MonoBehaviour
    {
        public static ExternalChat Instance;

        private void Awake() {
            Instance = this;
        }

        [SerializeField] private UnityEvent OnExternalChatPrompt;
        public void OpenPrompt() {
            OnExternalChatPrompt?.Invoke();
        }
    }
}