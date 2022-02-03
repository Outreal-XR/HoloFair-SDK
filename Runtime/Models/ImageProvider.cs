using UnityEngine;

namespace outrealxr.holomod
{
    public class ImageProvider : LinkProvider
    {

        public MeshRenderer meshRenderer;

        public override string ModKey => "image";

        public override string providerType => GetType().Name;

    }
}