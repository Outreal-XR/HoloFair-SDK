using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.avatars
{
    [RequireComponent(typeof(AvatarController))]
    public class AvatarView : MonoBehaviour
    {
        AvatarController controller;

        public Avatar avatar;

        public GameObject loadingVisual, queuedVisual, userTag;
        public UnityEvent OnReveal, OnConceal;
        
        private void Awake()
        {
            controller = GetComponent<AvatarController>();
        }

        /// <summary>
        /// Must be called by input system whenever user hovers mouse on a collider of avatar
        /// </summary>
        public void RequestToReveal(string src)
        {
            if (!loadingVisual.activeSelf) controller.UpdateModel(src);
        }

        internal void Reveal(Avatar avatar) {
            this.avatar = avatar;
            if (avatar == null) return;

            var animator = avatar.GetComponent<Animator>();
            if (animator != null) animator.applyRootMotion = false;
            
            if (userTag) {
                userTag.SetActive(!avatar.isProp);
            }
            
            OnReveal.Invoke();
        }


        internal void Conceal()
        {
            avatar = null;
            
            if (userTag)
                userTag.SetActive(true);
            
            OnConceal.Invoke();
        }
    }
}