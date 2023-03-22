using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.outrealxr.avatars
{
    public class MousePointer : MonoBehaviour
    {
        void Update() {
            if (Mouse.current.leftButton.wasPressedThisFrame) {
                Vector3 mousePos = Mouse.current.position.ReadValue();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out RaycastHit hit)) {
                    revised.AvatarView view = hit.collider.GetComponent<revised.AvatarView>();
                    if (view) view.Reveal();
                }
            }
        }
    }
}