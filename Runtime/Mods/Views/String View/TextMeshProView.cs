using TMPro;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class TextMeshProView : StringView
    {
        [SerializeField] private TMP_Text _text;
        
        public override void SetValue(string value, Vector3 position) {
            base.SetValue(value, position);
            _text.SetText(value);
        }
    }
}