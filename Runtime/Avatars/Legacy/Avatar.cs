using com.outrealxr.avatars.revised;
using UnityEngine;

namespace com.outrealxr.avatars
{
    public class Avatar : MonoBehaviour
    {
        private AvatarModel _owner;
        public int type;
        public bool isProp;

        public void SetOwner(AvatarModel owner)
        {
            if (_owner != null) _owner.AvatarRemoved();
            _owner = owner;
            transform.parent = this._owner ? _owner.transform : AvatarsProvider.instance.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(this._owner);
            if (_owner != null) _owner.AvatarAssigned();
        }
    }
}