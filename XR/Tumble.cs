namespace Field.XR
{
    using UnityEngine;
    using GameCreator.Core;
    using GameCreator.Variables;
    using HurricaneVR.Framework.Core.Utils;

    public abstract class Tumble : MonoBehaviour
    {
        public static string EVENT_NAME = "FIELD_EVENT_TUMBLE_UNLOCKED";
        public NumberProperty Timer;
        public NumberProperty Degrees;
        public BoolProperty Unlocked;
        public BoolProperty DoneRotating;
        public AudioClip SFXOpen;
        public float _elapsed;
        public void Unlock()
        {
            if (!Unlocked.GetValue(gameObject))
            {
                if (SFXPlayer.Instance) SFXPlayer.Instance.PlaySFX(SFXOpen, transform.position);
            }
            Unlocked.value = true;
            EventDispatchManager.Instance.Dispatch(Tumble.EVENT_NAME, this.gameObject);
        }

        void Update()
        {
            if (!Unlocked.GetValue(gameObject) || DoneRotating.GetValue(gameObject))
                return;
            this.Condition();
        }
        
        public abstract void Condition();
    }
}