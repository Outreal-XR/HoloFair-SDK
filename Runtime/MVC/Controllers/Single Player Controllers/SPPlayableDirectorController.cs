using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SPPlayableDirectorController : Controller
    {
        private PlayableDirectorModel _model;

        private void OnEnable()
        {
            Init();
        }

        public void Init()
        {
            SetModel(GetComponentInParent<PlayableDirectorModel>());
        }

        public void SetModel(PlayableDirectorModel model)
        {
            _model = model;
        }

        public override void Write()
        {
            
        }

        public override void Handle()
        {
            
        }

        public override void Read()
        {
            
        }

        public override void ReadForAll()
        {
            
        }
    }
}