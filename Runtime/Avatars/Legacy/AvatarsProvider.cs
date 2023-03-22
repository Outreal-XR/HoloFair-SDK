using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.avatars
{
    public class AvatarsProvider : MonoBehaviour
    {

        public List<AvatarLoadingOperation> avatarLoadingOperations;

        int currentID;
        public AvatarLoadingOperation currentOperation;
        public static AvatarsProvider instance;

        private void Awake()
        {
            instance = this;
        }

        public void LoadAvatar(AvatarModel model, int type, string url)
        {
            currentID = model.GetInstanceID();
            currentOperation = avatarLoadingOperations[type];
            currentOperation.Handle(model, url);
        }

        public bool IsLoading(AvatarModel model)
        {
            return model.GetInstanceID() == currentID && model.isLoading;
        }
    }
}