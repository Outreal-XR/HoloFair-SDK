using com.outrealxr.networkimages;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ImageView : LinkView
    {
        [SerializeField] protected NetworkImage _networkImage;

        protected override void Start() {
            base.Start();
            LoadImage();
        }

        public void LoadImage() {
            _networkImage.SetAndEnqueue(GetValue);
            print("loading image");
        }

        public override void SetValue(string value, Vector3 position) {
            base.SetValue(value, position);
            LoadImage();
        }
    }
}