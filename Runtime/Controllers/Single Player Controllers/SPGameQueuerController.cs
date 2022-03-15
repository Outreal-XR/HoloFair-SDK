using System.Collections;
using System.Collections.Generic;
using outrealxr.holomod;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace outrealxr.holomod
{
    public class SPGameQueuerController : Controller
    {
        private GameQueuerProvider _model;

        private void OnEnable() {
            Init();
        }

        public void Init() => SetModel(GetComponentInParent<GameQueuerProvider>());
        public void SetModel(GameQueuerProvider model) => _model = model;


        public void Queue() {
            
        }

        public void Dequeue() {
            
        }

        public void ForceGameStart() {
            
        }

        public override void Handle() {
            Debug.LogWarning($"[{GetType().Name}] There is no Handle logic implemented. Please use View.SendMessageToController to call Queue or Dequeue methods instead.");
        }

        public override void Sync() {
            throw new System.NotImplementedException();
        }

        public override void Read() {
            throw new System.NotImplementedException();
        }

        public override void ReadForAll() {
            throw new System.NotImplementedException();
        }
    }
}