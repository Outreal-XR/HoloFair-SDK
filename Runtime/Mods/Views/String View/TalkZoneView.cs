using System;

namespace com.outrealxr.holomod
{
    public class TalkZoneView : StringView
    {
        private Action<string> _onJoin;

        public void RegisterJoin(Action<string> action) =>_onJoin = action;

        private Action _onLeave;

        public void RegisterLeave(Action action) => _onLeave = action;

        public override string Tags => "talkezone";

        public virtual void Join()
        {
            _onJoin?.Invoke(GetValue);
            Analytics.instance.RecordStart(this, GetValue);
        }
        
        public virtual void Leave()
        {
            _onLeave?.Invoke();
            Analytics.instance.RecordEnd(this, GetValue);
        }

        public override string GetValue => string.IsNullOrWhiteSpace(base.GetValue) ? _guid.GetStringGuid() : base.GetValue;
    }
}