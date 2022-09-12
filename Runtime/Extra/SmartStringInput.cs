using SaG.GuidReferences;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod.Runtime
{
    public class SmartStringInput : MonoBehaviour
    {
        [SerializeField] private GuidComponent guid;
        [SerializeField, TextArea(3, 10)] private string stringFormat;

        [SerializeField] private UnityEvent<string> OnFormatChange;

        public void Format() {
            OnFormatChange.Invoke(SmartStringSource.Instance.GetFormattedString(stringFormat, guid.GetStringGuid()));
        }
    }
}