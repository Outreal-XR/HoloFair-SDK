using com.outrealxr.networkimages;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ImageView : LinkView
    {
        [SerializeField] private NetworkImage _networkImage;

        public void LoadImage() {
            _networkImage.SetAndEnqueue(GetValue);
        }

        public override void SetValue(string value, Vector3 position) {
            base.SetValue(value, position);
            LoadImage();
        }
    }
}