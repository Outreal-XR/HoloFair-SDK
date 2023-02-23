using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.holomod
{
    public abstract class UserView : StringView
    {
        [SerializeField] protected UnityEvent OnValid;
        [SerializeField] protected UnityEvent OnInvalid;

        public abstract void CompareValues();
    }
}