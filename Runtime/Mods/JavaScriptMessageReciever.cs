using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class JavaScriptMessageReciever : MonoBehaviour
    {

        public static JavaScriptMessageReciever instance;
        JavaScriptMessageParser parser;

        void Start()
        {
            instance = this;
            gameObject.name = "JavaScriptMessageReciever";
        }

        //Used by JavaScript
        public void Process(string input)
        {
            parser.Parse(input);
        }

        public void StartEdit(JavaScriptMessageParser parser)
        {
            this.parser = parser;
            parser.OpenView();
        }
    }
}