namespace Field
{
    using UnityEngine.Events;
    using GameCreator.Core;
    using GameCreator.Shooter;
    using HurricaneVR.Framework.Components;
    public class FieldDamageHandler : HVRDamageHandlerBase
    {
        public TargetGameObject shooter = new TargetGameObject(TargetGameObject.Target.Invoker);
        public override void TakeDamage(float damage)
        {
            //Sync up the shooter damage provider with HurricaneVR home grown shooter system.
            CharacterShooter shooterValue = this.shooter.GetComponent<CharacterShooter>(gameObject);
            IgniterOnReceiveShot[] ignitersTarget = this.shooter.GetComponentsInChildren<IgniterOnReceiveShot>(gameObject);
            for (int i = 0; i < ignitersTarget.Length; ++i)
            {
                if (ignitersTarget[i] != null)
                {
                    ignitersTarget[i].OnReceiveShot(
                        shooterValue,
                        CharacterShooter.ShotType.Normal,
                        ignitersTarget[i].transform.position
                    );
                }
            }
        }
    }
}