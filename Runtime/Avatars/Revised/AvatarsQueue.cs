using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace com.outrealxr.avatars.revised
{
    public static class AvatarsQueue
    {
        private static readonly Queue<AvatarOwner> Queue = new();

        public static void Enqueue(AvatarOwner owner)
        {
            Queue.Enqueue(owner);
            owner.SetQueued();

            if (Queue.Count == 1) {
                StartOperation();
            }
        }

        private static async void StartOperation() {
            if (Queue.Count == 0) return;

            var owner = Queue.Peek();
            owner.SetDequeued();

            if (owner.IsVisible) {
                var operation = await AvatarOperationFactory.GetOperation(owner);
                await operation.Operate();
            }

            Queue.Dequeue();
            
            if (Queue.Count != 0) StartOperation();
        }
    }
}