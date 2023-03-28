using System.Collections.Generic;

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

        private static void StartOperation() {
            if (Queue.Count == 0) return;
            
            var current = Queue.Dequeue();
            current.SetDequeued();

            AvatarLoadingOperation operation = current.Src.EndsWith("glb") || current.Src.EndsWith("gltf")
                ? new RPMAvatarOperation()
                : new AddressableAvatarOperation();

            operation.OnOperationCompleted += StartOperation;
            
            if (current.IsVisible) 
                operation.Handle(current);
        }
    }
}