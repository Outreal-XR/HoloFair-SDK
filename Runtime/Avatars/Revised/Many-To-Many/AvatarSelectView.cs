using System;
using UnityEngine;
using UnityEngine.UI;

namespace com.outrealxr.avatars.ManyToMany
{
    public class AvatarSelectView : MonoBehaviour
    {
        [SerializeField] private Image _avatarImage;
        private Action _onButtonClick;

        public void InvokeAction() => _onButtonClick?.Invoke();

        public void UpdateView(Sprite sprite, Action onButtonClick) {
            _avatarImage.sprite = sprite;
            _onButtonClick = onButtonClick;
        }
    }
}