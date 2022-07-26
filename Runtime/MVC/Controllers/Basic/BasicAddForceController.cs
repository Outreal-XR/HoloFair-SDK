using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicAddForceController : Controller
    {
        [SerializeField] private Rigidbody playerRb;
        
        public override void Handle() {
            (model as AddForceModel).playerRb = playerRb;
            model.view.Apply();
        }
    }
}