using TMPro;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class TextMeshProView : StringView
    {
        [SerializeField] private TMP_Text _text;
        
        public override void SetValue(string value) {
            base.SetValue(value);
            _text.SetText(value);
        }
    }
}