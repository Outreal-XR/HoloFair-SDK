using System;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SimpleInteractionsController : MonoBehaviour
    {
        [SerializeField] private Camera sourceCamera;
        [SerializeField] private float maxRayDistance = 100f;

        private OnClickHandler _focusedClickHandler;

        [Space (10), SerializeField] private bool hasClicked = false;
        
        private void Update() {
            var ray = sourceCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, maxRayDistance)) {
                var newHandler = hit.collider.GetComponent<OnClickHandler>();
                
                if (newHandler != null) {
                    if (newHandler != _focusedClickHandler)
                        newHandler.OnEnter.Invoke();
                    else
                        _focusedClickHandler.OnExit.Invoke();
                } else if (_focusedClickHandler != null) {
                    _focusedClickHandler.OnExit.Invoke();
                    hasClicked = false;
                } else {
                    hasClicked = false;
                }

                _focusedClickHandler = newHandler;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && _focusedClickHandler != null) {
                hasClicked = true;
            } else if (Input.GetKeyUp(KeyCode.Mouse0) && _focusedClickHandler != null) {
                if (hasClicked)
                    _focusedClickHandler.OnClick?.Invoke();
            }
        }

    }
}