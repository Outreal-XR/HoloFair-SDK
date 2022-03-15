using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SPLinkController : Controller
    {
        public string originUrl = "https://holofair.b-cdn.net";
        private LinkProvider _model;

        private void OnEnable() {
            Init();
        }

        public void Init() {
            SetModel(GetComponentInParent<LinkProvider>());
        }

        public void SetModel(LinkProvider model) {
            _model = model;
        }

        public override void Sync()
        {
            
        }

        public override void Handle()
        {
            var url = _model.url.Contains("https") ? _model.url : (originUrl + _model.url);
            Application.OpenURL(url);
        }

        public override void Read()
        {
            
        }

        public override void ReadForAll()
        {
            
        }
    }
}