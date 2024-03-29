using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class LinkView : StringView
    {
        public override string Tags => "link";

        public override void Edit()
        {
            JavaScriptMessageReciever.instance.StartEdit(new LinkParser(this));
        }

        public void OpenInNewTab() {
            throw new NotImplementedException("[LinkView] Not implemented, please, use OpenInSameTab()");
        }

        public void OpenInSameTab() {
            Application.OpenURL(GetValue);
            Analytics.instance.RecordImmediate(this, GetValue);
        }
    }
}