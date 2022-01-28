namespace Field.XR
{
    using UnityEngine;
    public class GlassRotate : Tumble
    {
        public override void Condition()
        {
            _elapsed += UnityEngine.Time.deltaTime;

            transform.localRotation = transform.localRotation * Quaternion.Euler(new Vector3(-Degrees.GetValue(gameObject) / Timer.GetValue(gameObject) * Time.deltaTime, 0f, 0f));
            if (_elapsed > Timer.GetValue(gameObject))
            {
                _elapsed = 0f;
                DoneRotating.value = true;
            }
        }
    }
}
