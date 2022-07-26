using UnityEngine;

namespace outrealxr.holomod
{
    [CreateAssetMenu(fileName = "New Question Data", menuName = "HoloFairSDK/Create Question Data")]
    public class QuestionData : ScriptableObject
    {
        public string question;
        public string[] options;
        public int correctIndex;
        public bool available;
    }
}