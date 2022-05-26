using System;
using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicFocusPointView : View
    {
        private BasicFocusPointController basicFocusPointController => (BasicFocusPointController)controller;

        
        public override void Apply() {
            Debug.LogWarning("[BasicFocusPointView] Value updated in model, but no Apply logic is provided.");
        }

        public override void Edit() {
            Debug.LogWarning("[BasicFocusPointView] This mod object has no edit functionality.");
        }

        public void SetAsFocusPoint() {
            basicFocusPointController.SetNewFocusPoint(((FocusPointModel)model).focusPoint);
        }

        public void ResetFocusPoint() {
            basicFocusPointController.ResetFocusToPlayer();
        }
    }
}