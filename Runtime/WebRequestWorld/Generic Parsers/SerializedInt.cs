namespace outrealxr.holomod.Runtime
{
    public class SerializedInt : GenericSerializedVar<int>
    {
        public void SetValue(SerializedInt otherVar) => value = otherVar.value;
    }
}