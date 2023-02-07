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

        public override void Edit()
        {
            JavaScriptMessageReciever.instance.StartEdit(new ImageParser(this));
        }

        public void LoadImage() {
            if (_networkImage == null) {
                Debug.LogError($"[ImageView] The network image field of \"{gameObject.name}\" is null!");
                return;
            }
            _networkImage.SetAndEnqueue(GetValue);
            Debug.Log($"[ImageView]  Fetching image...");
        }

        public override void SetValue(string value) {
            base.SetValue(value);
            LoadImage();
        }

        public NetworkImage NetworkImage => _networkImage;
    }
}