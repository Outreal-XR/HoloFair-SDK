using UnityEngine;

namespace outrealxr.holomod
{
    public class OptionsView : MonoBehaviour
    {
        [SerializeField] private BasicQuestionModel model;
        [SerializeField] private BasicQuestionView view;

        [SerializeField] private OptionView[] views;
        
        public void UpdateOptions() {
            for (var i = 0; i < views.Length; i++) {
                if (i < model.options.Length)
                    views[i].UpdateOption(model.options[i].OptionText, () => view.Answer(model.options[i].ID));
            }
        }
    }   
}