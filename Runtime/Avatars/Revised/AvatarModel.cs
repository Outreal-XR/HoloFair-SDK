using UnityEngine;

namespace com.outrealxr.avatars.revised
{
    public enum State
    {
        None,
        Queued,
        Loading,
        Set
    }

    public class AvatarModel
    {
        public string src = "ybot basic";
        public AvatarView view;
        public bool loading;
        public bool queued;
        GameObject avatar;

        public AvatarModel(string src)
        {
            this.src = src;
        }

        public AvatarModel(string src, AvatarView view)
        {
            this.src = src;
            this.view = view;
        }

        public void SetSource(string src)
        {
            this.src = src;
            view.Reveal();
        }

        public string GetSource()
        {
            return src;
        }

        public void Queued()
        {
            loading = false;
            queued = true;
            view.SetState(State.Queued);
            //Debug.Log($"[AvatarModel] Queued {src}");
        }

        public void Dequeued()
        {
            loading = true;
            queued = false;
            view.SetState(State.Loading);
            //Debug.Log($"[AvatarModel] Dequeued {src}");
        }

        public void SetAvatar(GameObject avatar)
        {
            loading = false;
            queued = false;
            if (this.avatar) Object.Destroy(this.avatar);
            this.avatar = avatar;
            if (this.avatar)
            {
                this.avatar.transform.parent = view.transform;
                this.avatar.transform.localPosition = Vector3.zero;
                this.avatar.transform.localRotation = Quaternion.identity;
            }
            if(!view.gameObject.activeInHierarchy) Object.Destroy(this.avatar);
            view.SetState(this.avatar ? State.Set : State.None);
        }

        public bool IsVisible()
        {
            return view != null && view.gameObject.activeInHierarchy;
        }

        public override string ToString()
        {
            return (view ? view.gameObject.name : "missing view") + $": {src}";
        }
    }
}