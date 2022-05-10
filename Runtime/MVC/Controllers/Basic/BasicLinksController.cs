using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicLinksController : Controller
    {
        public override void Handle()
        {
            Application.OpenURL(((LinkModel)model).value);
        }
    }
}