
using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.holomod
{
    public class UserGroupView : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnValid;
        [SerializeField] private UnityEvent OnInvalid;
    }
}
