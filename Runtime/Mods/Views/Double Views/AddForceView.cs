using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class AddForceView : DoubleView
    {
        [SerializeField] private ForceMode _forceMode;

        private Action<double> _applyForce;

        public void SetAction(Action<double> applyForce) => _applyForce = applyForce;

        public void ApplyForce() => _applyForce?.Invoke(GetValue);
    }

}