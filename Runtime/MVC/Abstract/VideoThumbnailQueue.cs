using com.outrealxr.networkimages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class VideoThumbnailQueue : MonoBehaviour
    {
        public struct ThumbnailQueueEntry
        {
            public string url;
            public NetworkImage networkImage;
            public float timestamp;

            public ThumbnailQueueEntry(string url, NetworkImage networkImage, float timestamp)
            {
                this.url = url;
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
                return $"{networkImage} at {timestamp} seconds";
            }
        }

        protected Queue<ThumbnailQueueEntry> queue = new Queue<ThumbnailQueueEntry>();
        public static VideoThumbnailQueue instance;

        public void Awake()
        {
            instance = this;
        }

        internal void Queue(string url, NetworkImage networkImage, float timestamp)
        {
            ThumbnailQueueEntry thumbnailQueueEntry = new ThumbnailQueueEntry(url, networkImage, timestamp);
            if (queue.Contains(thumbnailQueueEntry))
            {
                Debug.LogWarning($"[VideoThumbnailQueue] Already queued ${thumbnailQueueEntry}. Skipped");
                return;
            }
            Debug.Log($"[VideoThumbnailQueue] Queued ${thumbnailQueueEntry}");
            queue.Enqueue(thumbnailQueueEntry);
            TryNext();
        }

        public abstract void TryNext();
    }
}