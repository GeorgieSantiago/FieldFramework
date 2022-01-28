namespace Field.XR
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GameCreator.Core;
    using GameCreator.Variables;


    [AddComponentMenu("")]
    public class IgniterSafeDialUnlocked : Igniter
    {
#if UNITY_EDITOR
        public new static string NAME = "Field/XR/Safe Dial Unlocked";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
#endif

        [SerializeField] private GameObjectProperty target;

        private void Start()
        {
            EventDispatchManager.Instance.Subscribe(SafeDial.EVENT_NAME, (GameObject _tumble) =>
            {
                if (_tumble == target.GetValue(gameObject))
                {
                    this.ExecuteTrigger(_tumble);
                }
            });
        }
    }
}