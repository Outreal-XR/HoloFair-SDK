using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class LockModel : StringModel
    {
        [SerializeField] private string password;
        [SerializeField] private UnityEvent OnSuccess;
        [SerializeField] private UnityEvent OnFail;
        
        public void AttemptPassword (string input) {
            if (input.Equals(password)) 
                OnSuccess?.Invoke();
            else 
                OnFail?.Invoke();
        }
    }
}
