using System.Collections;
using System.Collections.Generic;
using outrealxr.holomod;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SPImageController : Controller
    {
        public ImageProvider _model;
        public Texture texture;
        
        private void OnEnable()
        {
            Init();
        }

        public void Init()
        {
            SetModel(GetComponentInParent<ImageProvider>());
        }

        public void SetModel(ImageProvider model)
        {
            _model = model;
            Handle();
        }
        
        public override void Handle() {
            _model.meshRenderer.material.SetTexture(_model.textureProperty, texture);
        }

        public override void Sync() {
        }

        public override void Read() {
        }

        public override void ReadForAll() {
        }
    }
}