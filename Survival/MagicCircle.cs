namespace Field.Survival
{
    using UnityEngine;
    using GameCreator.Inventory;
    using GameCreator.Variables;
    using HurricaneVR.Framework.Core;
    using HurricaneVR.Framework.Core.Grabbers;
    using HurricaneVR.Framework.Core.Sockets;
    [RequireComponent( typeof( ListVariables ) )]
    public class MagicCircle : MonoBehaviour
    {
        [SerializeField] private HVRSocketContainer container;
        private int circlePower;
        private ListVariables componentList = new ListVariables();
        private void Start()
        {
            container = GetComponentInChildren<HVRSocketContainer>();
            circlePower = container.Sockets.Count;
            foreach (var socket in container.Sockets)
            {
                socket.Grabbed.AddListener((HVRGrabberBase grabbable, HVRGrabbable grabbed) =>
                {
                    Debug.Log("We have a cap");
                    Debug.Log(socket.gameObject.name);
                    grabbed.TryGetComponent(out Item item);
                    if (item != null)
                    {
                        Debug.Log("Oh snap we are getting somehwere");
                        VariablesManager.ListPush(componentList, ListVariables.Position.Next, grabbed);
                    }
                });

                socket.Released.AddListener((HVRGrabberBase grabbable, HVRGrabbable grabbed) =>
                {
                    Debug.Log("We have a release");
                    Debug.Log(socket.gameObject.name);
                    grabbed.TryGetComponent(out Item item);
                    if (item != null)
                    {
                        Debug.Log("Oh snap we are getting somehwere");
                        VariablesManager.ListPush(componentList, ListVariables.Position.Next, grabbed);
                    }
                });
            }
        }
    }
}