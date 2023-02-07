namespace outrealxr.holomod.Runtime
{
    public class SerializedBool : GenericSerializedVar<bool>
    {
        public void SetValue(SerializedBool otherVar) {
            value = otherVar.value;
            OnValueUpdate?.Invoke(value);
        }

    }
}