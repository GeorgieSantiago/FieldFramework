namespace GameCreator.Core
{
    using UnityEngine;
    using System.Collections;
    using GameCreator.Variables;
    using HurricaneVR.Framework.Core;
    using HurricaneVR.Framework.Core.Sockets;
    using HurricaneVR.Framework.Core.Grabbers;
    public enum ContainerChange
    {
        Add,
        Remove
    }
    [AddComponentMenu("")]
    public class IgniterOnContainerChange : Igniter
    {
#if UNITY_EDITOR
        public new static string NAME = "Field/XR/On Container Change";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
#endif
        [SerializeField] private GameObjectProperty container;
        [SerializeField] private ContainerChange change;
        [SerializeField] private GameObjectProperty storeInteractionItem;

        private void Start()
        {
            StartCoroutine(nameof(AwaitContainerChange));
        }

        private IEnumerator AwaitContainerChange()
        {
            var _container = this.container.GetValue(gameObject).GetComponentInChildren<HVRSocketContainer>();

            _container.Sockets.ForEach((HVRSocket action) =>
            {
                var eventListener = change == ContainerChange.Add ? action.Grabbed : action.Released;
                action.Grabbed.AddListener((HVRGrabberBase grabber, HVRGrabbable grabbed) =>
                {
                    storeInteractionItem.value = grabbed.gameObject;
                    this.ExecuteTrigger(gameObject);
                });
            });
            yield return null;
        }
    }
}