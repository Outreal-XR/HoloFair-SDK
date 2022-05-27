using com.outrealxr.networkimages.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class VideoThumbnailQueue : MonoBehaviour
    {
        public struct ThumbnailQueueEntry
        {
            public NetworkImage networkImage;
            public float timestamp;

            public ThumbnailQueueEntry(NetworkImage networkImage, float timestamp)
            {
                this.networkImage = networkImage;
                this.timestamp = timestamp;
            }

            public override int GetHashCode()
            {
                return networkImage.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return networkImage.Equals(obj);
            }

            public override string ToString()
            {
                return networkImage.ToString();
            }
        }

        Queue<ThumbnailQueueEntry> queue = new Queue<ThumbnailQueueEntry>();
        public static VideoThumbnailQueue instance;

        public void Awake()
        {
            instance = this;
        }

        internal void Queue(NetworkImage networkImage, float timestamp)
        {
            ThumbnailQueueEntry thumbnailQueueEntry = new ThumbnailQueueEntry(networkImage, timestamp);
            if (queue.Contains(thumbnailQueueEntry))
            {
                Debug.LogWarning($"[NetworkImageQueue] Already queued ${networkImage}. Skipped");
                return;
            }
            Debug.Log($"[NetworkImageQueue] Queued ${networkImage}");
            queue.Enqueue(thumbnailQueueEntry);
            TryNext();
        }

        public abstract void TryNext();
    }
}