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
            if (this._owner) this._owner.AvatarRemoved();
            this._owner = owner;
            transform.parent = this._owner ? this._owner.transform : AvatarsProvider.instance.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(this._owner);
            if (this._owner) this._owner.AvatarAssigned();
        }
    }
}