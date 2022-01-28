namespace Field
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GameCreator.Variables;
    using GameCreator.Core;
    public class ConditionButton : MonoBehaviour
    {
        [SerializeField] private NumberProperty unlockAtValue;
        [SerializeField] private NumberProperty currentValue;

        private void Start() {
            if(currentValue.GetValue(gameObject) < unlockAtValue.GetValue(gameObject)) {
                this.GetComponent<ButtonActions>().interactable = false;
            }
        }
    }

}