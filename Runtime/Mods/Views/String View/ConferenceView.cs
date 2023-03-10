using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ConferenceView : TalkZoneView
    {
        [SerializeField] private string[] _roles;
        [SerializeField] private string[] _mutedRoles;
        

        public bool IsModerationOn = false;

        private Action<string, bool, string[], string[]> _onJoin;

        public void RegisterJoin(Action<string, bool, string[], string[]> action) => _onJoin = action;

        private Action _onLeave;

        public void RegisterLeave(Action action) => _onLeave = action;

        public virtual void Join()
        {
            _onJoin?.Invoke(GetValue, IsModerationOn, _roles, _mutedRoles);
            Analytics.instance.RecordStart(this, GetValue);
        }

        public virtual void Leave()
        {
            _onLeave?.Invoke();
            Analytics.instance.RecordEnd(this, GetValue);
        }

        public override string GetValue => string.IsNullOrWhiteSpace(base.GetValue) ? _guid.GetStringGuid() : base.GetValue;

        public void SetIsModerationOn(bool val)
        {
            IsModerationOn = val;
        }

        public override string Tags => "conference";
    }
}