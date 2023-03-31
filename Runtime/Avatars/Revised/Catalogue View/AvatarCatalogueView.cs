using UnityEngine;

namespace com.outrealxr.avatars.revised
{
    public abstract class AvatarCatalogueView : MonoBehaviour
    {
        protected static AvatarCatalogueView DefaultView;
        protected static AvatarCatalogueView CustomView;

        public static GameObject MainView => CustomView != null ? CustomView.gameObject : DefaultView.gameObject;

        private void Start() {
            MainView.SetActive(LocalAvatarOwner.Instance.IsAvatarDefault && gameObject.Equals(MainView));
        }

        public void Select(string src) {
            LocalAvatarOwner.Instance.SetSrc(src);
        }
    }
}