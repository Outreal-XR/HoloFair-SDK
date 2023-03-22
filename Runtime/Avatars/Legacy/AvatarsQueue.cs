using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.avatars
{
    public class AvatarsQueue : MonoBehaviour
    {

        public class AvatarModelQueue
        {
            public int AvatarType;
            public string url;
            public AvatarModel model;

            public override string ToString()
            {
                return $"{url}";
            }
        }
        
        public Queue<AvatarModelQueue> queue = new();

        public static AvatarsQueue instance;
        public static AvatarModelQueue current;

        AvatarModelQueue[] queueArray;

        [SerializeField] private AvatarsProvider provider;

        private void Awake()
        {
            instance = this;

            if (!provider) provider = GetComponent<AvatarsProvider>();
        }
        
        public void Enqueue(AvatarModel model)
        {
            queueArray = queue.ToArray();
            model.SetIsLoading(true);
            
            queue.Enqueue(new AvatarModelQueue{
                AvatarType = model.type,
                url = model.src,
                model = model
            });
            //Debug.Log($"[AvatarsQueue] Queued {model.src}");

            if (queue.Count == 1) TryNext();
        }

        public void TryNext()
        {
            queueArray = queue.ToArray();
            if (queue.Count == 0) {
                current = null;
                return;
            }

            if (current == null)
            {
                if (!current.model.isLoading)
                {
                    current = queue.Dequeue();
                    if (current.model.gameObject.activeInHierarchy)
                    {
                        current.model.Apply(current.AvatarType, current.url);
                    }
                    else
                    {
                        current.model.Complete(null);
                    }
                }
            }
        }

#if UNITY_EDITOR
        void OnGUI()
        {
            if (queueArray != null)
            {
                // Make a background box
                GUI.Box(new Rect(32, 32, 512, 64 + 32 * queueArray.Length), "Queue");
                GUI.Label(new Rect(32, 64, 512 - 32, 32), text: "Current: " + current);
                for (int i = 0; i < queueArray.Length; i++)
                    GUI.Label(new Rect(32, 96 + 32 * i, 512 - 32, 128 - 32), queueArray[i].ToString());
            }
            
        }
#endif
    }
}