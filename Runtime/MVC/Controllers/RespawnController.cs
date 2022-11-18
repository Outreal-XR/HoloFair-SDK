using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace outrealxr.holomod
{
    public class RespawnController : MonoBehaviour
    {
        public float radius = 0.1f;
        [Tooltip("Feel free to assign a different rigidbody, however if null it will GameObject.FindGameObjectWithTag(\"LocalPlayer\").GetComponent<Rigidbody>()")]
        public Rigidbody player;
        NavMeshAgent navMeshAgent;

        void Awake()
        {
            if (player == null) player = GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<Rigidbody>();
            if (player) navMeshAgent = player.GetComponentInChildren<NavMeshAgent>();
        }

        public void Respawn()
        {
            if (navMeshAgent) navMeshAgent.ResetPath();
            player.position = GetRespawnPosition();
            player.rotation = transform.rotation;
        }

        Vector3 GetRespawnPosition()
        {
            var randPos = Random.insideUnitCircle * radius;
            return new Vector3(randPos.x, 0, randPos.y) + transform.position;
        }
    }
}