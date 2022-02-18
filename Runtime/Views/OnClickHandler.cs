using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnClickHandler : MonoBehaviour
    {
        public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;
        public UnityEvent OnEnter, OnDown, OnUp, OnExit, OnClick;

        public void ReplaceCursor(bool isHovered)
        {
            Cursor.SetCursor(isHovered ? cursorTexture : null, isHovered ? hotSpot : Vector2.zero, cursorMode);
        }
    }
}