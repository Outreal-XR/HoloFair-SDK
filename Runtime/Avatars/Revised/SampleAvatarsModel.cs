using UnityEngine;

namespace com.outrealxr.avatars.revised
{
    public class SampleAvatarsModel : AvatarsModel
    {
        public AvatarView[] users;
        public string[] srcs;
        public float delay = 5;
        int index = 0;
        float nextUserTime;

        void Start()
        {
            for (int i = 0; i < users.Length; i++)
                UpdateAvatarModel(i, users[i], srcs[i % srcs.Length]);
        }

        void Update()
        {
            if(Time.time > nextUserTime)
            {
                nextUserTime = Time.time + delay;
                UpdateAvatarModel(index, users[index], srcs[Random.Range(0, srcs.Length)]);
                index++;
                index %= users.Length;
            }
        }
    }
}