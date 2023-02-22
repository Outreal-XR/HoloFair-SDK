using System;
using SaG.GuidReferences;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class SmartStringInput : MonoBehaviour
    {
        [SerializeField] private GuidComponent guid;
        [SerializeField, TextArea(3, 10)] private string stringFormat;

        [SerializeField] private UnityEvent<string> OnFormatChange;

        private void Start() {
            Format();
        }

        public void Format() {
            OnFormatChange.Invoke(SmartStringSource.Instance.GetFormattedString(stringFormat, guid.GetStringGuid()));
        }
    }
}