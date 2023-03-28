using com.outrealxr.avatars.revised;
using UnityEngine;

namespace com.outrealxr.avatars
{
    public abstract class AvatarCatalogueView : MonoBehaviour
    {
        public CanvasGroup canvasGroup;

        protected static AvatarCatalogueView DefaultView;
        protected static AvatarCatalogueView CustomView;

        public static GameObject MainView => CustomView != null ? CustomView.gameObject : DefaultView.gameObject;

        private void Start() {
            MainView.SetActive(LocalAvatarOwner.Instance.IsAvatarDefault);
        }

        public void Select(string src) {
            LocalAvatarOwner.Instance.SetSrc(src);
        }
    }
}