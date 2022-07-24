using System;
using com.outrealxr.networkimages;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace outrealxr.holomod
{
    public class OptionView : MonoBehaviour
    {
        [SerializeField] private NetworkImageUIImage image;
        [SerializeField] private Button button;

        public void UpdateOption(string optionUrl, Action onClick) {
            image.SetAndEnqueue(optionUrl);
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => onClick());
        }
    }
}