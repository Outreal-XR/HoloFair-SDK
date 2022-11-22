using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public interface IExecutable
    {
        void Execute();
        bool ExecuteOnStart();
    }
}