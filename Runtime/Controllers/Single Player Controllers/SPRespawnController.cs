using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SPRespawnController : Controller
    {

        public RespawnProvider respawnProvider;
        
        [Tooltip("Must be gameObject which represents Local User")]
        public Transform playerTransform;

        private void OnEnable()
        {
            Init();
        }

        public void Init() => SetModel(GetComponentInParent<RespawnProvider>());
        public void SetModel(RespawnProvider provider) => respawnProvider = provider;

        public override void Handle() {
            if (respawnProvider == null) Init(); 
            
            var randPos = Random.insideUnitCircle * respawnProvider.radius;

            playerTransform.transform.position = new Vector3(randPos.x, 0, randPos.y) + respawnProvider.transform.position;
        }

        public override void Sync() {
            
        }

        public override void Read() {
            
        }

        public override void ReadForAll() {
            
        }
    }
}