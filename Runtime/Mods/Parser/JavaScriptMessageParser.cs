using System.Runtime.InteropServices;

namespace com.outrealxr.holomod
{
    public abstract class JavaScriptMessageParser
    {
#if UNITY_WEBGL
        [DllImport("__Internal")]
        protected static extern void OpenEdit(string name, string id, string edittype, string value);
#else
        protected static void OpenEdit(string name, string id, string edittype, string value)
        {
            UnityEngine.Debug.Log($"[JavaScriptMessageParser] Unable to open edit on current platform: " + UnityEngine.Application.platform);
        } 
#endif
        public abstract void Parse(string input);
        public abstract void OpenView();
    }
}