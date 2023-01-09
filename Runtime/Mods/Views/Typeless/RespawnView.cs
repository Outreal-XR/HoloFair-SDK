using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class RespawnView : View
    {
        [SerializeField] private Transform _respawnPoint;

        private Action<Vector3> _onRespawn;
        public void RegisterAction(Action<Vector3> action) => _onRespawn = action;

        public void Respawn() {
            _onRespawn?.Invoke(_respawnPoint.position);
        }
    }
}