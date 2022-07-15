using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class BasicStringController : Controller
    {
        protected StringModel stringModel;

        public override void SetModel(Model model)
        {
            base.SetModel(model);
            stringModel = (StringModel)model;
        }

        public void SetValue(string val)
        {
            stringModel.SetValue(val);
        }
    }
}