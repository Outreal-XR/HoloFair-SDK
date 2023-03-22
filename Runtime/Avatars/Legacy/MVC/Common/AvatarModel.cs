using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.avatars
{
    [RequireComponent(typeof(AvatarView))]
    public class AvatarModel : MonoBehaviour
    {
        AvatarView view;
        Avatar current;

        public int type;
        public string src;
        public bool isLoading;
        public bool isLocal;
        IPlayerAnimation playerAnimation;

        public static AvatarModel instance;

        private void Awake()
        {
            view = GetComponent<AvatarView>();
            SetIsLocal(isLocal);
        }

        public void Reveal() {
            if (view.avatar == null && !isLoading) view.RequestToReveal(src);
        }

        public void SetIsLocal(bool val)
        {
            isLocal = val;
            if (isLocal) instance = this;
        }

        public void SetSource(string src)
        {
            this.src = src;
        }

        internal void SetSFSPlayerAnimation(IPlayerAnimation playerAnimation)
        {
            this.playerAnimation = playerAnimation;
        }

        public void SetIsLoading(bool val)
        {
            if (view)
            {
                if(view.queuedVisual) view.queuedVisual.SetActive(val);
                else Debug.Log($"[AvatarModel] View.waitingVisual on {gameObject} is missing?");
            }
            else
            {
                Debug.Log($"[AvatarModel] View on {gameObject} is missing?");
            }
            isLoading = val;
        }

        public void Apply(int type, string url)
        {
            if (gameObject.activeInHierarchy) {
                if(view.queuedVisual) view.queuedVisual.SetActive(false);
                if(view.loadingVisual) view.loadingVisual.SetActive(true);

                AvatarsProvider.instance.LoadAvatar(this, type, url);
            } else if(current) Destroy(current.gameObject);
        }

        public void Dequeue() {
            if(view.loadingVisual) view.loadingVisual.SetActive(false);
            SetIsLoading(false);
        }

        public void FreeUpAvatar() {
            if (!current) return;
            Destroy(current.gameObject);
        }


        [SerializeField] private UnityEvent OnAvatarComplete;
        public void Complete(Avatar avatar) {
            FreeUpAvatar();
            
            if(view.loadingVisual) view.loadingVisual.SetActive(false);
            if(view.queuedVisual) view.queuedVisual.SetActive(false);
            
            current = avatar;
            if (current) {
                current.SetOwner(this);
                playerAnimation?.ReadUserVariable();
            }
            SetIsLoading(false);

            OnAvatarComplete?.Invoke();

            AvatarsQueue.instance.TryNext();
        }

        public void AvatarAssigned()
        {
            view.Reveal(current);
        }

        public void AvatarRemoved()
        {
            view.Conceal();
        }

        private void OnDisable()
        {
            if (AvatarsProvider.instance.IsLoading(this)) AvatarsProvider.instance.currentOperation.Stop();
        }

        public bool HasAvatar => current;
    }
}