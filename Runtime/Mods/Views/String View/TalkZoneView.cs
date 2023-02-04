using System;

namespace com.outrealxr.holomod
{
    public class TalkZoneView : StringView
    {
        private Action<string> _onJoin;
        public void RegisterJoin(Action<string> action) =>_onJoin = action;

        public void Join()
        {
            _onJoin?.Invoke(GetValue);
            Analytics.instance.RecordStart(this, GetValue);
        }
        
        private Action _onLeave;
        public void RegisterLeave(Action action) => _onLeave = action;
        public void Leave()
        {
            _onLeave?.Invoke();
            Analytics.instance.RecordEnd(this, GetValue);
        }
    }
}