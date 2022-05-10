using UnityEngine;

namespace outrealxr.holomod
{
    public class SPImageController : Controller
    {
        public ImageModel _model;
        public Texture texture;
        
        private void OnEnable()
        {
            Init();
        }

        public void Init()
        {
            SetModel(GetComponentInParent<ImageModel>());
        }

        public override void SetModel(Model model)
        {
            _model =(ImageModel) model;
            Handle();
        }
        
        public override void Handle() {
            _model.meshRenderer.material.SetTexture(_model.textureProperty, texture);
        }
    }
}