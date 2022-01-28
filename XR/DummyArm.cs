using HurricaneVR.Framework.Core.ScriptableObjects;
using HurricaneVR.Framework.Core.Utils;
using HurricaneVR.Framework.Shared;
using UnityEngine;

namespace Field.XR
{
    [RequireComponent(typeof(ConfigurableJoint))]
    public class DummyArm : MonoBehaviour
    {
        public Transform Anchor;
        public float Length = .5f;
        public LineRenderer Rope;
        public Transform ArmRopeAnchor;

        void Start()
        {
            var joint = GetComponent<ConfigurableJoint>();
            joint.SetLinearLimit(Length);
            joint.anchor = ArmRopeAnchor.localPosition;
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = Anchor.position;
            Rope.positionCount = 2;
        }

        // Update is called once per frame
        void Update()
        {
            Rope.SetPosition(0, Anchor.position);
            Rope.SetPosition(1, ArmRopeAnchor.position);
        }
    }
}
