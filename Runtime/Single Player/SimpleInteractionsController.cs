using System;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SimpleInteractionsController : MonoBehaviour
    {
        [SerializeField] private Camera sourceCamera;
        [SerializeField] private LayerMask mask;
        [SerializeField] private float maxRayDistance = 100f;

        private OnClickHandler _focusedClickHandler;

        [Space (10), SerializeField] private bool hasClicked = false;
        
        private void Update() {
            var ray = sourceCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, maxRayDistance, mask)) {
                var newHandler = hit.collider.GetComponent<OnClickHandler>();
                
                if (newHandler != null) {
                    if (newHandler != _focusedClickHandler)
                        newHandler.OnEnter.Invoke();
                    else
                        _focusedClickHandler.OnExit.Invoke();
                } else if (_focusedClickHandler != null) {
                    newHandler.OnExit.Invoke();
                    hasClicked = false;
                } else {
                    hasClicked = false;
                }

                _focusedClickHandler = newHandler;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                _focusedClickHandler.OnDown?.Invoke();
                hasClicked = true;
            } else if (Input.GetKeyUp(KeyCode.Mouse0)) {
                _focusedClickHandler.OnUp?.Invoke();
                if (hasClicked)
                    _focusedClickHandler.OnClick?.Invoke();
            }
        }

    }
}