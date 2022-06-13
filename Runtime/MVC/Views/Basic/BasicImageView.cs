using UnityEngine;
using com.outrealxr.networkimages;

namespace outrealxr.holomod
{
    public class BasicImageView : BasicLinkView
    {
        [Tooltip("Target place where url of an image or video thumbnail is processed")]
        public NetworkImage networkImage;

        public override void Apply()
        {
            networkImage.SetAndEnqueue(((ImageModel)model).value);
        }
    }
}