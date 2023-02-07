using System;
using UnityEngine;
using UnityEngine.Playables;

namespace com.outrealxr.holomod
{
    public class PlayableDirectorView : DoubleView
    {
        [SerializeField] private double _lagCompensation;
        [SerializeField] private PlayableDirector _director;

        public override void Edit()
        {
            JavaScriptMessageReciever.instance.StartEdit(new PlayableDirectorParser(this));
        }

        public void Play() {
            _director.Play();
        }
        
        public void Stop() {
            _director.Stop();
        }

        public override void SetValue(double value) {
            base.SetValue(value);

            if (!_director) {
                Debug.LogError($"[PlayableDirectorView] The director field of \"{gameObject.name}\" is null!");
                return;
            }

            _lagCompensation = (UniversalTime.Now - value) / 1000;

            if (_director.time == 0) _director.Play();
            if (UniversalTime.Now >= value) _director.time = _lagCompensation;
        }

        public override string Tags => "director";
    }
}