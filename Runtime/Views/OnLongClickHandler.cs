using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnLongClickHandler : MonoBehaviour
    {
        public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;
        public float longClickDuration = 0.5f;
        public UnityEvent OnHold, OnLongClick;
    
        public void ReplaceCursor(bool isHovered)
        {
            Cursor.SetCursor(isHovered ? cursorTexture : null, isHovered ? hotSpot : Vector2.zero, cursorMode);
        }
    }
}
