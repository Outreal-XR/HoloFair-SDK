using UnityEngine;

namespace com.outrealxr.holomod
{
    public abstract class EmotesSelectView : MonoBehaviour
    {
        protected static EmotesSelectView DefaultView;
        protected static EmotesSelectView CustomView;
        
        public static GameObject MainView => CustomView != null ? CustomView.gameObject : DefaultView.gameObject;

        public void ToggleMain() {
            MainView.SetActive(!MainView.activeSelf);
        }
    }
}
