namespace Field
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
    using GameCreator.Core;
    using GameCreator.Variables;

    [AddComponentMenu("")]
    public class OnDamage : Igniter 
	{
		#if UNITY_EDITOR
        public new static string NAME = "Field/On Damage";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
        #endif
        public GameObjectProperty target;
        private void Start()
        {
            EventDispatchManager.Instance.Subscribe("FIELD_DAMAGE_EVENT", (GameObject _target) => {
                if(target.GetValue(_target) == _target) {
                    this.ExecuteTrigger(gameObject);
                }
            });
        }
	}
}