namespace outrealxr.holomod.Runtime
{
    public class SerializedFloat : GenericSerializedVar<float> {
        public void SetValue(SerializedFloat otherVar) => value = otherVar.value;
    }
}