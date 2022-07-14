using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class LockModel : StringModel
    {
        [SerializeField] private UnityEvent OnSuccess;
        [SerializeField] private UnityEvent OnFail;
        
        public void AttemptPassword (string input) {
            if (input.Equals(value)) 
                OnSuccess?.Invoke();
            else 
                OnFail?.Invoke();
        }
    }
}
