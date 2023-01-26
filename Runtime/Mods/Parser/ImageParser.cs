using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ImageParser : LinkParser
    {
        [DllImport("__Internal")]
        private static extern void OpenImageEdit();

        public ImageParser(ImageView view) : base(view) { }

        public override void OpenView()
        {
            OpenImageEdit();
        }
    }
}