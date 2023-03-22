using UnityEngine;

namespace com.outrealxr.avatars
{
    public class AvatarLocalControllerTest : AvatarLocalController
    {
        public override bool IsAvatarSet()
        {
            return false;
        }

        public override void UpdateLocalModel(string src)
        {
            AvatarModel.instance.gameObject.GetComponent<PlayerAvatarView>().RequestToReveal(src);
        }
    }
}