using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace outrealxr.holomod
{
    public class PromptView : MonoBehaviour
    {
        [SerializeField] GameObject promptCanvas;

        [SerializeField] TextMeshProUGUI titleText, questionText;
        [SerializeField] Transform buttonsParent;
        [SerializeField, Space(10)] Button buttonPrefab;

        List<Button> _buttonPool;

        [SerializeField] bool isMain;
        public static PromptView instance;

        private void Awake() {
            _buttonPool = new List<Button>();

            for (var i = 0; i < 20; i++) {
                var button = Instantiate(buttonPrefab, buttonsParent);
                button.gameObject.SetActive(false);
                _buttonPool.Add(button);
            }
            if (isMain) instance = this;
            promptCanvas.SetActive(false);
        }

        public void ShowPrompt(string title, string question, PromptModel.PromptOptionModel[] answers) {
            promptCanvas.SetActive(true);

            foreach (var button in _buttonPool) {
                button.gameObject.SetActive(false);
                button.onClick.RemoveAllListeners();
            }

            titleText.text = title;
            questionText.text = question;

            for (var i = 0; i < answers.Length; i++) {
                var answer = answers[i];
                var button = _buttonPool[i];

                button.gameObject.SetActive(true);
                button.GetComponentInChildren<TextMeshProUGUI>().text = answer.answerName;
                button.onClick.AddListener(() => {
                    promptCanvas.SetActive(false);
                    answer.OnClick?.Invoke();
                });
            }
        }


    }
}