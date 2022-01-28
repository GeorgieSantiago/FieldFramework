

namespace Field.XR
{
    using System.Collections;
    using GameCreator.Core;
    using GameCreator.Variables;
    using HurricaneVR.Framework.Core;
    using HurricaneVR.Framework.Core.Grabbers;
    using HurricaneVR.Framework.Core.Utils;
    using UnityEngine;
    using UnityEngine.Events;
    [RequireComponent(typeof(PassthroughSocket))]
    public class Lock : MonoBehaviour
    {
        public static string EVENT_NAME = "FIELD_EVENT_LOCK_UNLOCKED";
        public PassthroughSocket Socket;
        public HVRGrabbable FaceGrabbable;
        public GameObjectProperty Face;
        public Transform Key;
        public NumberProperty AnimationTime;
        public AudioClip SFXUnlocked;
        public AudioClip SFXKeyInserted;
        public NumberProperty LockThreshold;
        private bool _unlocked;

        public void Start()
        {
            Socket = GetComponent<PassthroughSocket>();
            Socket.Grabbed.AddListener(OnKeyGrabbed);
        }

        public void Update()
        {
            if (!_unlocked && FaceGrabbable.transform.localRotation.eulerAngles.x > LockThreshold.GetValue(gameObject))
            {
                _unlocked = true;
                EventDispatchManager.Instance.Dispatch(EVENT_NAME, this.gameObject);
                FaceGrabbable.ForceRelease();
                FaceGrabbable.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                FaceGrabbable.CanBeGrabbed = false;
                FaceGrabbable.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                if (SFXPlayer.Instance) SFXPlayer.Instance.PlaySFX(SFXUnlocked, FaceGrabbable.transform.position);
            }
        }

        private void OnKeyGrabbed(HVRGrabberBase grabber, HVRGrabbable key)
        {
            StartCoroutine(MoveKey(key));
        }

        private IEnumerator MoveKey(HVRGrabbable key)
        {
            var start = key.transform.position;
            var startRot = key.transform.rotation;

            var elapsed = 0f;
            while (elapsed < AnimationTime.GetValue(gameObject))
            {
                float animTime = AnimationTime.GetValue(gameObject);
                key.transform.position = Vector3.Lerp(start, Key.position, elapsed / animTime);
                key.transform.rotation = Quaternion.Lerp(startRot, Key.rotation, elapsed / animTime);

                elapsed += Time.deltaTime;
                yield return null;
            }

            if (SFXPlayer.Instance) SFXPlayer.Instance.PlaySFX(SFXKeyInserted, FaceGrabbable.transform.position);
            FaceGrabbable.gameObject.SetActive(true);
            Face.GetValue(gameObject).SetActive(false);
            Destroy(key.gameObject);
        }

    }
}