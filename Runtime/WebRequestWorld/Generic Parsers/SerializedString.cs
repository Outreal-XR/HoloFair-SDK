namespace outrealxr.holomod.Runtime
{
    public class SerializedString : GenericSerializedVar<string>
    {
        public void SetValue(SerializedString otherVar) {
            value = otherVar.value;
            OnValueUpdate?.Invoke(value);
        }
    }
}