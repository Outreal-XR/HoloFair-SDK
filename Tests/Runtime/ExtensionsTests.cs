using Newtonsoft.Json.Linq;
using NUnit.Framework;
using UnityEngine;

namespace outrealxr.holomod.Tests
{
    public class ExtensionsTests
    {
        [Test]
        public void ExtensionsTestsSimplePasses()
        {
            GameObject gameObject = new GameObject("BaseModel", typeof(Model));
            gameObject.transform.position = new Vector3(1, -1, 4);
            Model baseModel = gameObject.GetComponent<Model>();
            JObject jvector3 = baseModel.transform.position.ToJObject();
            Debug.Log($"[ExtensionsTests] jvector3 = {jvector3}");
            JObject jtransform = baseModel.ToJObject();
            Debug.Log($"[ExtensionsTests] jtransform = {jtransform}");
        }

    }
}