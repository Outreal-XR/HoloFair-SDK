using System;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class PromptController : MonoBehaviour
    {
        [SerializeField, TextArea(5, 10)] private string promptQuestion;
        [SerializeField] private PromptAnswer[] answers;
        
        public void OpenPrompt(PromptView view) {
            view.ShowPrompt(promptQuestion, answers);
        }

        [Serializable]
        public class PromptAnswer
        {
            public string answerName;
            public UnityEvent OnClick;
        }
    }
}