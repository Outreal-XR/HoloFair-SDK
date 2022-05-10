using UnityEngine;

namespace outrealxr.holomod
{
    public class SPGameQueuerController : Controller
    {
        public void Queue() {
            
        }

        public void Dequeue() {
            
        }

        public void ForceGameStart() {
            
        }

        public override void Handle() {
            Debug.LogWarning($"[{GetType().Name}] There is no Handle logic implemented. Please use View.SendMessageToController to call Queue or Dequeue methods instead.");
        }
    }
}