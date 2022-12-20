using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class PlayableDirectorView : StringView
    {
        [SerializeField] private double _lagCompensation;
        
        public void Play() {
            throw new NotImplementedException();
        }
        
        public void Stop() {
            throw new NotImplementedException();
        }

        public override string GetValue => throw new NotImplementedException();
    }
}