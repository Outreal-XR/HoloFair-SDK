using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class UTCTimerParser : JavaScriptMessageParserT<string>
    {
        [DllImport("__Internal")]
        private static extern void OpenUTCTimerEdit();

        public UTCTimerParser(TimerView view) : base(view) { }

        public override void OpenView()
        {
            OpenUTCTimerEdit();
        }

        public override void Parse(string input)
        {
            view.SetValue(input);
        }
    }
}