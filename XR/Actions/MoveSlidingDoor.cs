namespace Field.XR
{
    using UnityEngine;
    using GameCreator.Core;

    [AddComponentMenu("")]
    public class MoveSlidingDoor : IAction
    {
        public SlidingDoor door;

        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            door.OpenDoors();
            return true;
        }

#if UNITY_EDITOR
        public static new string NAME = "Field/XR/Move Sliding Door";
#endif
    }
}
