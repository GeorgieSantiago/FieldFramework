namespace Field
{
    using UnityEngine;
	using UnityEngine.EventSystems;
    using GameCreator.Core;
    public class FieldEventBridge : MonoBehaviour
    {
        private void Start() {
            var target = FindObjectOfType<EventSystem>();
        }
    }
}