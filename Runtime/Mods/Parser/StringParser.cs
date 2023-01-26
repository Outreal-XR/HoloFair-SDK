using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class StringParser : JavaScriptMessageParserT<string>
    {
        [DllImport("__Internal")]
        private static extern void OpenTextEdit();

        public StringParser(StringView view) : base(view) { }

        public override void OpenView()
        {
            OpenTextEdit();
        }

        public override void Parse(string input)
        {
            view.SetValue(input);
        }
    }
}