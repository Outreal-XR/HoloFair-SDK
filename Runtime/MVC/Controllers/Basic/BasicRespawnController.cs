using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicRespawnController : Controller
    {
        public Rigidbody player;

        private void Awake()
        {
            if (player == null) player = GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<Rigidbody>();
        }

        public override void Handle()
        {
            player.position = ((RespawnModel)model).GetRespawnPosition();
            player.rotation = model.transform.rotation;
        }
    }
}