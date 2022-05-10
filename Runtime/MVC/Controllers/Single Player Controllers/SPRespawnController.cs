using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SPRespawnController : Controller
    {   
        [Tooltip("Must be gameObject which represents Local User")]
        public Transform playerTransform;

        public override void Handle() {
            RespawnModel _model = (RespawnModel)model; ; 
            var randPos = Random.insideUnitCircle * _model.radius;
            playerTransform.transform.position = new Vector3(randPos.x, 0, randPos.y) + _model.transform.position;
        }
    }
}