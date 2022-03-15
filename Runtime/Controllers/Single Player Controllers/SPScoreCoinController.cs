using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SPScoreCoinController : Controller
    {
        private ScoreCoinProvider _model;

        private void OnEnable() {
            Init();
        }

        public void Init() {
            SetModel(GetComponentInParent<ScoreCoinProvider>());
        }

        public void SetModel(ScoreCoinProvider provider) => _model = provider;

        public override void Handle() {
            _model.visual.SetActive(false);
        }

        public override void Sync() {
            
        }

        public override void Read()
        {
            
        }

        public override void ReadForAll()
        {
            
        }
    }
}
