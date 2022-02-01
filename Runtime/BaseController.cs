using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class BaseController : MonoBehaviour
    {
        public BaseModel model;

        public abstract void Execute();
    }
}