using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class LinkView : StringView
    {
        public override void Edit()
        {
            JavaScriptMessageReciever.instance.StartEdit(new LinkParser(this));
        }

        public void OpenInNewTab() {
            throw new NotImplementedException();
        }

        public void OpenInSameTab() {
            Application.OpenURL(GetValue);
        }
    }
}