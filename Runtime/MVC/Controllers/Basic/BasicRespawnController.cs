using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicRespawnController : Controller
    {
        public Transform player;

        public override void Handle()
        {
            player.position = ((RespawnModel)model).GetRespawnPosition();
        }
    }
}