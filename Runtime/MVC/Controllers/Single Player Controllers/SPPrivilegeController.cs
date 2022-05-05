using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SPPrivilegeController : Controller
    {
        private PrivilageModel provider;

        private void OnEnable()
        {
            Init();
            Handle();
        }

        public void Init()
        {
            SetModel(GetComponentInParent<PrivilageModel>());
        }

        public void SetModel(PrivilageModel provider)
        {
            this.provider = provider;
        }

        public override void Handle()
        {
            
        }

        public override void Write()
        {
            
        }

        public override void Read()
        {
            
        }

        public override void ReadForAll()
        {
            
        }
    }   
}