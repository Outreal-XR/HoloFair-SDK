using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SPScoreCoinController : Controller
    {
        private ScoreCoinModel _model;

        private void OnEnable() {
            Init();
        }

        public void Init() {
            SetModel(GetComponentInParent<ScoreCoinModel>());
        }

        public void SetModel(ScoreCoinModel provider) => _model = provider;

        public override void Handle() {
            _model.visual.SetActive(false);
        }

        public override void Write() {
            
        }

        public override void Read()
        {
            
        }

        public override void ReadForAll()
        {
            
        }
    }
}
