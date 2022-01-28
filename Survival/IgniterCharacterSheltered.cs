namespace Field.Survival
{
	using UnityEngine;
    using GameCreator.Core;

    [AddComponentMenu("")]
    public class IgniterCharacterSheltered : Igniter 
	{
		#if UNITY_EDITOR
        public new static string NAME = "Field/Survival/Character Is Sheltered";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
        #endif

        private void Start()
        {
            EventDispatchManager.Instance.Subscribe(SurvivalExposureUtil.GetExposureEventString(SurvivalExposure.Sheltered), (GameObject target) => {
                this.ExecuteTrigger(target);
            });
        }

	}
}