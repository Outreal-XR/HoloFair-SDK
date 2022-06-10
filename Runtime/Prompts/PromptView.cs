using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace outrealxr.holomod
{
    public class PromptView : MonoBehaviour
    {
        [SerializeField] private GameObject promptCanvas;

        [SerializeField] private TextMeshProUGUI questionText;
        [SerializeField] private Transform buttonsParent;
        [SerializeField, Space(10)] private Button buttonPrefab;

        private List<Button> _buttonPool;

        private void Awake() {
            _buttonPool = new List<Button>();

            for (var i = 0; i < 20; i++) {
                var button = Instantiate(buttonPrefab, buttonsParent);
                button.gameObject.SetActive(false);
                _buttonPool.Add(button);
            }
            
        }

        public void ShowPrompt(string question, PromptController.PromptAnswer[] answers) {
            foreach (var button in _buttonPool) {
                button.gameObject.SetActive(false);
                button.onClick.RemoveAllListeners();
            }
            
            questionText.text = question;

            for (var i = 0; i < answers.Length; i++) {
                var answer = answers[i];
                var button = _buttonPool[i];

                button.GetComponentInChildren<TextMeshProUGUI>().text = answer.answerName;
                button.onClick.AddListener(() => {
                    answer.OnClick?.Invoke();
                });
            }
        }


    }
}