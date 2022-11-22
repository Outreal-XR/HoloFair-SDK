using UnityEngine;

namespace outrealxr.holomod
{
    public class ImageModel : LinkModel
    {
        public override string type => "image";

        public override void SetValue(string value)
        {
            base.SetValue(value);
            Apply();
        }
    }
}