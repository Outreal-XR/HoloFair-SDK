using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.outrealxr.holomod
{
    public class RespawnView : DoubleView
    {
        [SerializeField] private Transform _respawnPoint;

        private Action<Vector3> _onRespawn;
        public void RegisterAction(Action<Vector3> action) => _onRespawn = action;

        public void Respawn() {
            var randomCircle = Random.insideUnitCircle * (float)_value;
            var offset = new Vector3(randomCircle.x, 0, randomCircle.y);
            _onRespawn?.Invoke(_respawnPoint.position + offset);
        }

        public override string Tags => "respawn";
    }
}