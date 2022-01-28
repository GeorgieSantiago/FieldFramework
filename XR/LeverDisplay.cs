namespace Field.XR
{
    using GameCreator.Variables;
    using TMPro;
    using UnityEngine;
    public class LeverDisplay : MonoBehaviour
    {
        private NumberProperty _step;
        private NumberProperty _angle;
        private TMP_Text _tm;

        private void Awake()
        {
            _tm = GetComponent<TMP_Text>();
        }

        public void OnStepChanged(int step)
        {
            _step.value = step;
            _tm.text = $"{_step}/{_angle:f0}";
        }

        public void OnAngleChanged(float angle, float delta)
        {
            _angle.value = angle;
            _tm.text = $"{_step}/{_angle:f0}";
        }
    }
}
