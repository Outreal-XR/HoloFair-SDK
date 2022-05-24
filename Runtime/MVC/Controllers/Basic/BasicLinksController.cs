using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicLinksController : Controller
    {
        LinkModel linkModel;

        public override void SetModel(Model model)
        {
            base.SetModel(model);
            linkModel = (LinkModel)model;
        }

        public override void Handle()
        {
            Application.OpenURL(((LinkModel)model).value);
        }

        public void SetValue(string val)
        {
            linkModel.value = val;
        }
    }
}