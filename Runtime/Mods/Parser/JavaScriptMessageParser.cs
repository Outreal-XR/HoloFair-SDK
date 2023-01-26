using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public abstract class JavaScriptMessageParser
    {
        public abstract void Parse(string input);
        public abstract void OpenView();
    }
}