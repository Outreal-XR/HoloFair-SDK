using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class DoubleParser : JavaScriptMessageParserT<double>
    {
        [DllImport("__Internal")]
        private static extern void OpenDoubleEdit();

        public DoubleParser(DoubleView view) : base(view) { }

        public override void OpenView()
        {
            OpenDoubleEdit();
        }

        public override void Parse(string input)
        {
            if(double.TryParse(input, out double result))
            {
                view.SetValue(result);
            }
            else
            {
                view.SetValue(0);
            }
        }
    }
}