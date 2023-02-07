using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class AddForceView : DoubleView
    {
        [SerializeField] private ForceMode _forceMode;

        private Action<Vector3, ForceMode> _applyForce;

        public void SetAction(Action<Vector3, ForceMode> applyForce) => _applyForce = applyForce;

        public void ApplyForce() => _applyForce?.Invoke(transform.up * (float) GetValue, _forceMode);
        public override string Tags => "addForce";
    }

}