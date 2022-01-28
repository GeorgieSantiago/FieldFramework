using HurricaneVR.Framework.Components;
using TMPro;
using UnityEngine;

namespace Field.XR
{
    public class KeypadButton : HVRPhysicsButton
    {
        public char Key;
        public TextMeshPro TextMeshPro;

        protected override void Awake()
        {
            ConnectedBody = transform.parent.GetComponentInParent<Rigidbody>();
            base.Awake();
        }
    }
}