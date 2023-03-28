using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.outrealxr.holomod
{
    public class RespawnView : DoubleView
    {
        [SerializeField] private Transform _respawnPoint;

        private Action<Vector3> _onRespawn;
        public void RegisterAction(Action<Vector3> action) => _onRespawn = action;

        public void Respawn()
        {
            var randomCircle = Random.insideUnitCircle * (float)_value;
            var offset = new Vector3(randomCircle.x, 0, randomCircle.y);
            _onRespawn?.Invoke(_respawnPoint.position + offset);
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            if (_respawnPoint)
            {
                Handles.color = Color.green;
                Handles.DrawWireDisc(_respawnPoint.position, Vector2.up, (float)_value);
            }
        }

        private void OnValidate()
        {
            if (!_respawnPoint)
            {
                _respawnPoint = new GameObject("Respawn Point").transform;
                _respawnPoint.SetParent(transform);
            }

        }
#endif
        public override string Tags => "respawn";
    }
}