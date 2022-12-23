using System;

namespace com.outrealxr.holomod
{
    public class AvatarView : StringView
    {
        private Action<string> _onSelect;
        public void RegisterAction(Action<string> action) => _onSelect = action;
        public void Select() => _onSelect?.Invoke(GetValue);
    }
}