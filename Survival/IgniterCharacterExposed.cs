namespace Field.Survival
{
    using UnityEngine;
    using GameCreator.Core;

    [AddComponentMenu("")]
    public class IgniterCharacterExposed : Igniter
    {
#if UNITY_EDITOR
        public new static string NAME = "Field/Survival/Character Is Exposed";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
#endif
        public SurvivalExposure type;
        public bool all;
        private void Start()
        {
            if (type == SurvivalExposure.RainExposure || all)
            {
                RainExposure();
            }

            if (type == SurvivalExposure.ColdExposure || all)
            {
                SnowExposure();
            }

            if (type == SurvivalExposure.Exposure || all)
            {
                Exposure();
            }
        }

        private void RainExposure()
        {
            EventDispatchManager.Instance.Subscribe(SurvivalExposureUtil.GetExposureEventString(SurvivalExposure.RainExposure), (GameObject target) =>
            {
                this.ExecuteTrigger(target);
            });
        }

        private void SnowExposure()
        {
            EventDispatchManager.Instance.Subscribe(SurvivalExposureUtil.GetExposureEventString(SurvivalExposure.ColdExposure), (GameObject target) =>
            {
                this.ExecuteTrigger(target);
            });
        }

        private void Exposure()
        {
            EventDispatchManager.Instance.Subscribe(SurvivalExposureUtil.GetExposureEventString(SurvivalExposure.Exposure), (GameObject target) =>
            {
                this.ExecuteTrigger(target);
            });
        }
    }
}