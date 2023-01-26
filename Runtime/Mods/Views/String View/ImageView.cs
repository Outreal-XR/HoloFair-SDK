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
            _networkImage.SetAndEnqueue(GetValue);
            print("loading image");
        }

        public override void SetValue(string value) {
            base.SetValue(value);
            LoadImage();
        }
    }
}