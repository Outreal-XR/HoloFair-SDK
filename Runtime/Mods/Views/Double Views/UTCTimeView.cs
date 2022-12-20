using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.holomod
{
    public class UTCTimeView : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnBefore;
        [SerializeField] private UnityEvent OnAfter;
    }
}