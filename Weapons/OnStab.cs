namespace Field.Weapon
{
    using UnityEngine;
    using GameCreator.Core;
    using GameCreator.Variables;
    using HurricaneVR.Framework.Core.Stabbing;

    [AddComponentMenu("")]
    public enum StabType
    {
        Stabbed,
        Unstabbed,
        FullStabbed,
        Any
    }
    public class OnStab : Igniter
    {
#if UNITY_EDITOR
        public new static string NAME = "Field/On Stab";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
#endif
        [SerializeField] private GameObjectProperty target;
        [SerializeField] private StabType type;
        [SerializeField] private GameObjectProperty storeStabber;
        private void Start()
        {
            var stabbable = target
              .GetValue(gameObject)
              .GetComponentInParent<HVRStabbable>();
            if (stabbable)
            {
                if (type == StabType.Stabbed || type == StabType.Any)
                {
                    stabbable.Stabbed.AddListener(StabEvent);
                }
                if (type == StabType.Unstabbed || type == StabType.Any)
                {
                    stabbable.UnStabbed.AddListener(StabEvent);
                }
                if (type == StabType.FullStabbed || type == StabType.Any)
                {
                    stabbable.FullStabbed.AddListener(StabEvent);
                }
            }

        }

        private void StabEvent(StabArgs stab) 
        {
            this.StabEvent(stab.Stabber, stab.Stabbable);
        }

        private void StabEvent(HVRStabber arg0, HVRStabbable arg1)
        {
            this.storeStabber.value = arg0.gameObject;
            this.ExecuteTrigger(arg1.gameObject);
        }
    }
}