using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public abstract class JavaScriptMessageParserT<T> : JavaScriptMessageParser
    {
        protected ViewT<T> view;

        public JavaScriptMessageParserT(ViewT<T> view)
        {
            this.view = view;
        }
    }
}