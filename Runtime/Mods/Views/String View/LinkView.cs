using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class LinkView : StringView
    {
        public void OpenInNewTab() {
            throw new NotImplementedException();
        }

        public void OpenInSameTab() {
            Application.OpenURL(GetValue);
        }
    }
}