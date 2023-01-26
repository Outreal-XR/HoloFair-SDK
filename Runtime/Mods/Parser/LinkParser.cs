using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class LinkParser : StringParser
    {
        [DllImport("__Internal")]
        private static extern void OpenLinkEdit();

        public LinkParser(LinkView view) : base(view) { }

        public override void OpenView()
        {
            OpenLinkEdit();
        }
    }
}