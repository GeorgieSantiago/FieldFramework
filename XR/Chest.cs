namespace Field.XR
{
    using UnityEngine;
    using GameCreator.Inventory;
    using HurricaneVR.Framework.Core;
    using HurricaneVR.Framework.Core.Sockets;
    using HurricaneVR.Framework.Core.Grabbers;
    [RequireComponent( typeof( Container ) )]
    public class Chest : MonoBehaviour
    {
        private Container itemContainerReference;
        [SerializeField] private HVRSocketContainer container;
        private void Awake()
        {
            itemContainerReference = GetComponent<Container>();
        }

        private void Start()
        {
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
                    }
                });

                socket.Released.AddListener((HVRGrabberBase grabbable, HVRGrabbable grabbed) =>
                {
                    Debug.Log("We have a release");
                    Debug.Log(socket.gameObject.name);
                    grabbed.TryGetComponent(out Item item);
                    if (item != null)
                    {
                        Debug.Log("Take something out of our inventory");
                    }
                });
            }
        }
    }
}