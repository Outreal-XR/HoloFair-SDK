using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class PlayableDirectorParser : DoubleParser
    {
        [DllImport("__Internal")]
        private static extern void OpenPlayerDirectorEdit();

        public PlayableDirectorParser(PlayableDirectorView view) : base(view) { }

        public override void OpenView()
        {
            OpenPlayerDirectorEdit();
        }
    }
}