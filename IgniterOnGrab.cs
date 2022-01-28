namespace GameCreator.Core
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
    using GameCreator.Variables;
    using HurricaneVR.Framework.Core.Grabbers;
    using HurricaneVR.Framework.Core;
    [AddComponentMenu("")]
    public class IgniterOnGrab : Igniter 
	{
		#if UNITY_EDITOR
        public new static string NAME = "Field/On Grab";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
        #endif
        public GameObjectProperty grabber;
        public GameObjectProperty storeGrabbable;
        private void Start()
        {
            grabber
            .GetValue(gameObject)
            .GetComponent<HVRGrabberBase>()
            .Grabbed
            .AddListener((HVRGrabberBase _grabber, HVRGrabbable _grabbed) => {
                if(storeGrabbable != null) {
                    storeGrabbable.value = _grabbed.gameObject;
                }
                this.ExecuteTrigger(gameObject);
            });
        }
	}
}