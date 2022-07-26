using System;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class PromptModel : MonoBehaviour
    {
        [SerializeField, TextArea(5, 10)] string title = "Confirmation needed", question = "Are you sure?";
        [SerializeField] PromptOptionModel[] options = { 
            new PromptOptionModel("Yes"),
            new PromptOptionModel("No")
        };
        public PromptView view;

        public void Prompt() {
            if (view != null) view.ShowPrompt(title, question, options);
            else PromptView.instance.ShowPrompt(title, question, options);
        }

        [Serializable]
        public class PromptOptionModel
        {
            public string answerName;
            public UnityEvent OnClick;

            public PromptOptionModel(string answerName)
            {
                this.answerName = answerName;
            }
        }
    }
}