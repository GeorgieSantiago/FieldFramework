namespace Field.Survival
{
    using UnityEngine;
    //@TODO pretty this
    public class SurvivalMode : ScriptableObject
    {
        public float biologyRate = 1f;
        public float biologyStep = 1f;
        public float dayNightStep = 1f;
        public float starvationThreshold = 50f;
        public float dehydrationThreshold = 50f;
    }
}