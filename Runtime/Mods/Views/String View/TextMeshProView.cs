using TMPro;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class TextMeshProView : StringView
    {
        [SerializeField] private TMP_Text _text;
        
        public override void SetValue(string value) {
            base.SetValue(value);
            if (!_text) {
                Debug.LogError($"[TextMeshProView] The text field of \"{gameObject.name}\" is null!");
                return;
            }
            _text.SetText(value);
        }

        public override string Tags => "tmp";
    }
}