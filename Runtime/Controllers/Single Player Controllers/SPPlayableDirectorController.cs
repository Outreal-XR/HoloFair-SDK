using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SPPlayableDirectorController : Controller
    {
        private PlayableDirectorProvider _model;

        private void OnEnable()
        {
            Init();
        }

        public void Init()
        {
            SetModel(GetComponentInParent<PlayableDirectorProvider>());
        }

        public void SetModel(PlayableDirectorProvider model)
        {
            _model = model;
        }

        public override void Sync()
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