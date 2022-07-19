using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace outrealxr.holomod
{
    public class OptionView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Button button;

        public void UpdateOption(string optionText, Action onClick) {
            text.text = optionText;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => onClick());
        }
    }
}