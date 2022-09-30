using UnityEngine;

namespace outrealxr.holomod
{
    [RequireComponent(typeof(BasicTextMeshProView))]
    public class TextMeshProModel : StringModel
    {
        public override string type => "textMeshPro";

        public override void SetValue(string value)
        {
            base.SetValue(value);
            Apply();
        }
    }
}