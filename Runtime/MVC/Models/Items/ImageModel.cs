using UnityEngine;

namespace outrealxr.holomod
{
    public class ImageModel : LinkModel
    {

        public MeshRenderer meshRenderer;
        public string textureProperty = "_BaseMap";

        public override string type => "image";

    }
}