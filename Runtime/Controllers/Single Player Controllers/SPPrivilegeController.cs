using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SPPrivilegeController : Controller
    {
        private PrivilageProvider provider;

        private void OnEnable()
        {
            Init();
            Handle();
        }

        public void Init()
        {
            SetModel(GetComponentInParent<PrivilageProvider>());
        }

        public void SetModel(PrivilageProvider provider)
        {
            this.provider = provider;
        }

        public override void Handle()
        {
            
        }

        public override void Sync()
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