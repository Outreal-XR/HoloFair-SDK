using UnityEngine;

namespace com.outrealxr.avatars
{
    public class Avatar : MonoBehaviour
    {
        public AvatarModel owner;
        public int type;
        public bool isProp;

        public void SetOwner(AvatarModel owner)
        {
            if (this.owner) this.owner.AvatarRemoved();
            this.owner = owner;
            transform.parent = this.owner ? this.owner.transform : AvatarsProvider.instance.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(this.owner);
            if (this.owner) this.owner.AvatarAssigned();
        }
    }
}