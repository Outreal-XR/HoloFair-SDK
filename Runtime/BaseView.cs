using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class BaseView : MonoBehaviour
    {
        public BaseModel model;

        public abstract void Execute();
    }
}