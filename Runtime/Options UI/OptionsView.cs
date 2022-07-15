using UnityEngine;

namespace outrealxr.holomod
{
    public class OptionsView : MonoBehaviour
    {
        [SerializeField] private BasicQuestionModel model;
        [SerializeField] private BasicQuestionView view;

        [SerializeField] private OptionView[] views;
        [SerializeField] private GameObject ui;
        
        public void UpdateOptions() {
            for (var i = 0; i < views.Length; i++) {
                if (i < model.options.Length) {
                    var id = model.options[i].ID;
                    
                    views[i].UpdateOption(model.options[i].OptionText, () => {
                            view.Answer(id);
                            ui.gameObject.SetActive(false);
                        });
                } else {
                    views[i].gameObject.SetActive(false);
                }
            }
        }
    }   
}