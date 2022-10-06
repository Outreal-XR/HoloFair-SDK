using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ZoneTalkModel : StringModel
    {
        public MeshRenderer videoMeshRenderer;
        public int materialIndex;
        public string materialPropertyName = "_BaseMap";

        public override string type => "zonetalk";
    }
}