using UnityEngine;

namespace com.outrealxr.avatars.revised
{
    public class AvatarModel
    {
        public enum State
        {
            None,
            Queued,
            Loading,
            Set
        }
        
        private string _src = "ybot basic";
        private readonly AvatarUser _user;
        GameObject _avatar;

        public AvatarModel(string src) => _src = src;

        public AvatarModel(string src, AvatarUser user) {
            _src = src;
            _user = user;
        }

        public bool CompareUser(AvatarUser user) => user.Equals(_user);

        public void SetSource(string src) {
            _src = src;
            _user.Reveal();
        }

        public string GetSource() => _src;

        public void Queued() => _user.SetState(State.Queued);

        public void Dequeued() => _user.SetState(State.Loading);

        public void SetAvatar(GameObject avatar) {
            if (this._avatar) Object.Destroy(this._avatar);
            this._avatar = avatar;
            if (this._avatar)
            {
                this._avatar.transform.parent = _user.transform;
                this._avatar.transform.localPosition = Vector3.zero;
                this._avatar.transform.localRotation = Quaternion.identity;
            }
            if(!_user.gameObject.activeInHierarchy) Object.Destroy(this._avatar);
            _user.SetState(this._avatar ? State.Set : State.None);
        }

        public bool IsVisible()
        {
            return _user != null && _user.gameObject.activeInHierarchy;
        }

        public override string ToString()
        {
            return (_user ? _user.gameObject.name : "missing view") + $": {_src}";
        }
    }
}