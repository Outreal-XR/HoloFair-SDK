using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class NavMeshAgentDestinationView : View
    {
        [SerializeField] private Transform _destination;
        private Action<Vector3> _onMove;

        public override string Tags => "navMeshAgentDestination";
        public void RegisterAction(Action<Vector3> action) => _onMove = action;

        public void Move()
        {
            _onMove.Invoke(_destination.position);
        }
    }
}