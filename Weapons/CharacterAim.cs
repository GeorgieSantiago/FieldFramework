namespace Field.Weapon
{
    using UnityEngine;
    using RootMotion.FinalIK;
    using GameCreator.Core;
    using GameCreator.Variables;
    using GameCreator.Shooter;
    [RequireComponent( typeof( AimIK ) )]
    [RequireComponent( typeof( BipedIK ) )]
    public class CharacterAim : MonoBehaviour
    {
        public GameObjectProperty m_Character;
        private IKSolverAim resolver;
        private CharacterShooter shooterRef;

        private void Wakeup()
        {
            this.resolver = (IKSolverAim)this.gameObject.GetComponent<AimIK>().GetIKSolver();
            shooterRef = m_Character.GetValue(gameObject).GetComponent<CharacterShooter>();
        }

        public void SetTarget(GameObject target)
        {
            if (this.resolver == null) { Wakeup(); }
            resolver.target = target.transform;
            resolver.transform = shooterRef.currentWeapon.prefab.transform;
        }

        public void SetTargetOnEvent(string eventName)
        {
            if (this.resolver == null) { Wakeup(); }
            EventDispatchManager.Instance.Subscribe(eventName, (GameObject nextTarget) => { this.SetTarget(nextTarget); });
        }

    }
}