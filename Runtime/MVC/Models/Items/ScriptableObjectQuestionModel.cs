using UnityEngine;

namespace outrealxr.holomod
{
    public class ScriptableObjectQuestionModel : BasicQuestionModel
    {
        [SerializeField] private QuestionData data;
        
        public override void GetData() {
            question = data.question;

            options = new Option[data.options.Length];
            for (var i = 0; i < options.Length; i++) {
                options[i].ID = i;
                options[i].OptionText = data.options[i];
            }
            
            if (data.available)
                OnAvailable?.Invoke();
            else
                OnUnavailable?.Invoke();
        }

        protected override void AvailableText(string text) {
            
        }

        public override void SelectOption(int i, float timeTaken) {
            if (i == data.correctIndex)
                OnCorrectAnswer?.Invoke();
            else 
                OnIncorrectAnswer?.Invoke();
        }
    }
}
