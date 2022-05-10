using outrealxr.holomod;
using UnityEngine.SceneManagement;

namespace thedrhax14.SFSUnityComponents.Runtime
{
    public class SPPortalController : Controller
    {
        public override void Handle() {
            SceneManager.LoadScene(((PortalProvider)model).sceneName);
        }
    }
}