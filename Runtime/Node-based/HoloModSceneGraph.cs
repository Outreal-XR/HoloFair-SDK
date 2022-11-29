using Newtonsoft.Json.Linq;
using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
    public class HoloModSceneGraph : SceneGraph<HoloModGraph>
    {
        private void Start() {
            ExecuteStartNodes();
        }

        public void ExecuteStartNodes() {

        }

    }
}