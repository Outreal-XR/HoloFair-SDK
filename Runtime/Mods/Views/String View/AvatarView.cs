using System;

namespace com.outrealxr.holomod
{
    public class AvatarView : StringView
    {
        private Action<string> _onSelect;

        protected override void Start()
        {
            base.Start();
            tags = "avatar";
        }

        public void RegisterAction(Action<string> action) => _onSelect = action;
        public void Select()
        {
            _onSelect?.Invoke(GetValue);
            Analytics.instance.RecordImmediate(this, GetValue);
        }
    }
}