using UnityEngine;

namespace outrealxr.holomod
{
    public class SPLinkController : Controller
    {
        public string originUrl = "https://holofair.b-cdn.net";
        private LinkModel _model;

        private void OnEnable() {
            Init();
        }

        public void Init() {
            SetModel(GetComponentInParent<LinkModel>());
        }

        public override void SetModel(Model model)
        {
            _model = (LinkModel)model;
        }

        public override void Handle()
        {
            var url = _model.value.Contains("https") ? _model.value : (originUrl + _model.value);
            Application.OpenURL(url);
        }
    }
}