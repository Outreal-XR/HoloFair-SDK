using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    /// <summary>
    /// When working witht the value of this class make sure to do the following in the controller
    /// string[] data = value.Split(",");
    /// if (data.Length == 1) title = data[0];
    /// if (data.Length == 2) endPoint = data[1];
    /// </summary>
    public class TextFeedbackModel : StringModel {
        public override string type => "textFeedback";
    }
}