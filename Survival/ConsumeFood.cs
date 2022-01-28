namespace GameCreator.Core
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("")]
	public class ConsumeFood : IAction
	{
		public int example = 0;

        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            Debug.Log(this.example);
            return true;
        }

		#if UNITY_EDITOR
        public static new string NAME = "Custom/ConsumeFood";
		#endif
	}
}
