using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnClickHandler : MonoBehaviour
    {
        public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;
        public UnityEvent OnEnter = new (), OnExit = new(), OnClick = new();
        bool hovered;

        void OnEnable()
        {
            OnEnter.AddListener(ShowCursor);
            OnExit.AddListener(HideCursor);
        }

        void OnDisable()
        {
            if (hovered) HideCursor();
            OnEnter.RemoveListener(ShowCursor);
            OnExit.RemoveListener(HideCursor);
        }

        void ShowCursor()
        {
            hovered = true;
            ReplaceCursor(true);
        }

        void HideCursor()
        {
            hovered = false;
            ReplaceCursor(false);
        }

        public void ReplaceCursor(bool isHovered)
        {
            Cursor.SetCursor(isHovered ? cursorTexture : null, isHovered ? hotSpot : Vector2.zero, cursorMode);
        }
    }
}