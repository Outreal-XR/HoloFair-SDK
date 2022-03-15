using System.Collections;
using System.Collections.Generic;
using outrealxr.holomod;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace thedrhax14.SFSUnityComponents.Runtime
{
    public class SPPortalController : Controller
    {
        private PortalProvider _model;

        private void OnEnable()
        {
            Init();
        }

        public void Init()
        {
            SetModel(GetComponentInParent<PortalProvider>());
        }

        public void SetModel(PortalProvider model)
        {
            _model = model;
        }

        public override void Handle() {
            SceneManager.LoadScene(_model.sceneName);
        }

        public override void Sync()
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