using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicLinksController : BasicStringController
    {
        public override void Handle()
        {
            Application.OpenURL(stringModel.value);
        }
    }
}