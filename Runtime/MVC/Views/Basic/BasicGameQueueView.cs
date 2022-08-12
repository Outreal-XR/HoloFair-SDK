namespace outrealxr.holomod.Runtime
{
    public class BasicGameQueueView : View
    {
        public override void Apply() {
            throw new System.NotImplementedException();
        }

        public override void Edit() {
            throw new System.NotImplementedException();
        }

        public void QueueUp() {
            var queueModel = model as GameQueueModel;
            (controller as BasicGameQueuerController).QueueUp(queueModel.maxQueueSize, queueModel.startDelayInSeconds, queueModel.guid, queueModel.areaOfInterest);
        }

        public void DeQueue() {
            (controller as BasicGameQueuerController).DeQueue(model.guid);
        }
    }
}