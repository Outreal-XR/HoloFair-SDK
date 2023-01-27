using System.Runtime.InteropServices;

namespace com.outrealxr.holomod
{
    public abstract class JavaScriptMessageParser
    {
        [DllImport("__Internal")]
        protected static extern void OpenEdit(string edittype);
        public abstract void Parse(string input);
        public abstract void OpenView();
    }
}