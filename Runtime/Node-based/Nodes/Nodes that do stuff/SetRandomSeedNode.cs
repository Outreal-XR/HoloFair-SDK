using UnityEngine;

namespace outrealxr.holomod
{
    public class SetRandomSeedNode : SequenceNode
    {
        [Input, SerializeField] private int _seed;
        
        protected override void ExecuteLogic() {
            if (GetInputPort("_seed").IsConnected) 
                _seed = GetInputValue<int>("_seed");
            
            Random.InitState(_seed);
        }
    }
}