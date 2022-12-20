using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class RigidbodyView : DoubleView
    {
        [SerializeField] private ForceMode _forceMode;

        public Action<double> _applyForce;
        
        public void ApplyForce(params Type[] type) {
            throw new NotImplementedException();
        }
    }

}