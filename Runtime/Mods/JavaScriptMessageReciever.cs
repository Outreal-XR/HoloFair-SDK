using UnityEngine;

namespace com.outrealxr.holomod
{
    public class JavaScriptMessageReciever : MonoBehaviour
    {

        public static JavaScriptMessageReciever instance;
        protected JavaScriptMessageParser parser;

        void Start()
        {
            instance = this;
            gameObject.name = "JavaScriptMessageReciever";
        }

        //Used by JavaScript
        public virtual void Process(string input)
        {
            parser.Parse(input);
            SetLock(false);
        }

        public virtual void StartEdit(JavaScriptMessageParser parser)
        {
            this.parser = parser;
            SetLock(true);
            
        }

        public virtual void SetLock(bool state)
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            WebGLInput.captureAllKeyboardInput = state;
            Debug.Log("[JavaScriptMessageReciever] WebGLInput.captureAllKeyboardInput: " + WebGLInput.captureAllKeyboardInput);
#endif
        }
    }
}