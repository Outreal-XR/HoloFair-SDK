using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class FocusPointModel : Model
    {
        public Transform focusPoint;
        
        public override string type => "focusPoint";
    }
}