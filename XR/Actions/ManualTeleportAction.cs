namespace Field.XR
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
    using GameCreator.Core;
	[AddComponentMenu("")]
	public enum GoToPosition {
		First,
		Second
	}
	public class ManualTeleportAction : IAction
	{
		[SerializeField] private ManualTeleport teleporter;
        [SerializeField] private GoToPosition position;

        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            if(position == GoToPosition.First) {
				teleporter.GoToOne();
				return true;
			}

			teleporter.GoToTwo();
            return true;
        }

		#if UNITY_EDITOR
        public static new string NAME = "Field/XR/Manual Teleport";
		#endif
	}
}
