namespace Field.XR
{
	using UnityEngine;
    using GameCreator.Core;
    using GameCreator.Variables;

    [AddComponentMenu("")]
    public class IgniterOnTumbleUnlocked : Igniter 
	{
		#if UNITY_EDITOR
        public new static string NAME = "Field/XR/Tumble Unlocked";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
        #endif

        [SerializeField] private GameObjectProperty target;

        private void Start()
        {
            EventDispatchManager.Instance.Subscribe(Tumble.EVENT_NAME, (GameObject _tumble) => {
                if(_tumble == target.GetValue(gameObject)) {
                    this.ExecuteTrigger(_tumble);
                }
            });
        }

	}
}