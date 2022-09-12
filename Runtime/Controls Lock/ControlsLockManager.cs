using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.zonetalks.Runtime
{
    public class ControlsLockManager : MonoBehaviour
    {
        public static ControlsLockManager Instance;
        
        [SerializeField] private List<ControlLocker> lockers = new();

        [SerializeField] private UnityEvent OnLock;

        private void Awake() {
            Instance = this;
        }

        public void AddLock(ControlLocker locker) {
            lockers.Add(locker);

            OnLock?.Invoke();
        }

        [SerializeField] private UnityEvent OnUnlock;
        public void RemoveLock(ControlLocker locker) {
            if (!lockers.Contains(locker)) return;
            
            lockers.Remove(locker);

            if (lockers.Count == 0)
                OnUnlock?.Invoke();
        }

    }
}