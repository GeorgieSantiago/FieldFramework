namespace Field.Survival
{
	using UnityEngine;
	using GameCreator.Core;
	using GameCreator.Variables;

	[AddComponentMenu("")]
	public class VariableNotEmpty : ICondition
	{
		public GameObjectProperty nullableVariable;

		public override bool Check(GameObject target)
		{
			return this.nullableVariable.GetValue(target) != null;
		}
        
		#if UNITY_EDITOR
        public static new string NAME = "Field/Variable Not Empty";
		#endif
	}
}
