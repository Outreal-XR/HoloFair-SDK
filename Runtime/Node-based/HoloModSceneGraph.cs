using XNode;

namespace outrealxr.holomod
{
    public class HoloModSceneGraph : SceneGraph<HoloModGraph>
    {
        private void Start() {
            graph.monoBehaviour = this;
            ExecuteStartNodes();
        }

        public void ExecuteStartNodes() {

        }
    }
}