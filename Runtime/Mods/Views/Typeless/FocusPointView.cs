using System;
using outrealxr.holomod;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class FocusPointView : View
    {
        [SerializeField] private FocusPoint _focusPoint;
        
        public override string Tags => "focusPoint";

        private Action<FocusPoint> _onSetFocusPoint;
        private Action _onReset;

        public void RegisterSetFocusPoint(Action<FocusPoint> action) => _onSetFocusPoint = action;
        public void RegisterOnReset(Action action) => _onReset = action;

        public void SetFocusPoint() {
            _onSetFocusPoint.Invoke(_focusPoint);
        }

        public void ResetToPlayer() {
            _onReset.Invoke();
        }

    }
}