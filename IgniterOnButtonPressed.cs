namespace Field
{
    using UnityEngine;
    using GameCreator.Variables;
    using GameCreator.Core;
    using UnityEngine.UI;

    public class IgniterOnButtonPressed : Igniter
    {

		#if UNITY_EDITOR
        public new static string NAME = "Field/On Button Pressed";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
        #endif        
        public GameObjectProperty button;
        private void Start()
        {
            button
              .GetValue(gameObject)
              .GetComponent<Button>().onClick.AddListener(() => {
                this.ExecuteTrigger(gameObject);
            });
        }
    }
}