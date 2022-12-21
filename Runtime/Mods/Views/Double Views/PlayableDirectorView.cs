using System;
using UnityEngine;
using UnityEngine.Playables;

namespace com.outrealxr.holomod
{
    public class PlayableDirectorView : DoubleView
    {
        [SerializeField] private double _lagCompensation;
        [SerializeField] private PlayableDirector _director;


        public void Play() {
            _director.Play();
        }
        
        public void Stop() {
            _director.Stop();
        }

        public override void SetValue(double value, Vector3 position) {
            base.SetValue(value, position);
            
            var now = DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            _lagCompensation = (now - value) / 1000;

            if (_director.time == 0) _director.Play();
            if (now >= value) _director.time = _lagCompensation;
        }
    }
}