using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    [RequireComponent(typeof(BasicTextMeshProView))]
    public class TextMeshProModel : StringModel
    {
        public override string type => "textMeshPro";

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            ((BasicTextMeshProView)view).textMeshPro.text = value;
        }
    }
}