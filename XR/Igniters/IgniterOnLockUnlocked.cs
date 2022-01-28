namespace Field.XR
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GameCreator.Core;
    using GameCreator.Variables;
    [AddComponentMenu("")]
    public class IgniterOnLockUnlocked : Igniter
    {
#if UNITY_EDITOR
        public new static string NAME = "Field/XR/On Lock Unlocked";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
#endif
        [SerializeField] private GameObjectProperty target;

        private void Start()
        {
            EventDispatchManager.Instance.Subscribe(Lock.EVENT_NAME, (GameObject _lock) =>
            {
                if (_lock == target.GetValue(gameObject))
                {
                    this.ExecuteTrigger(_lock);
                }
            });
        }
    }
}