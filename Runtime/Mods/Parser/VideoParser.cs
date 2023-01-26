using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class VideoParser : ImageParser
    {
        [DllImport("__Internal")]
        private static extern void OpenVideoEdit();

        public VideoParser(VideoView view) : base(view) { }

        public override void OpenView()
        {
            OpenVideoEdit();
        }
    }
}