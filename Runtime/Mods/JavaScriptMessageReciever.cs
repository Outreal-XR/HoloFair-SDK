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
        public virtual void Process(string input)
        {
            parser.Parse(input);
#if !UNITY_EDITOR && UNITY_WEBGL
            WebGLInput.captureAllKeyboardInput = true;
            Debug.Log("[JavaScriptMessageReciever] WebGLInput.captureAllKeyboardInput: " + WebGLInput.captureAllKeyboardInput);
#endif
        }

        public virtual void StartEdit(JavaScriptMessageParser parser)
        {
            this.parser = parser;
#if !UNITY_EDITOR && UNITY_WEBGL
            WebGLInput.captureAllKeyboardInput = false;
            Debug.Log("[JavaScriptMessageReciever] WebGLInput.captureAllKeyboardInput: " + WebGLInput.captureAllKeyboardInput);
#endif
            parser.OpenView();
        }
    }
}