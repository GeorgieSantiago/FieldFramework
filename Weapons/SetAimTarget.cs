namespace Field.Weapon
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using GameCreator.Core;
    using GameCreator.Variables;
    [AddComponentMenu("")]
    public class SetAimTarget : IAction
    {
        public TargetCharacter m_Character;
		public GameObjectProperty m_Target;
        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            m_Character
			  .GetCharacter(target)
			  .GetComponent<CharacterAim>()
			  .SetTarget(m_Target.GetValue(target));
            return true;
        }

#if UNITY_EDITOR
        public static new string NAME = "Field/Set Aim Target";
#endif
    }
}
