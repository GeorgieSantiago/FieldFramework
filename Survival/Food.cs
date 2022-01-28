namespace Field.Survival
{
    using UnityEngine;
    using GameCreator.Stats;

    public class Food : MonoBehaviour
    {
        [AttributeSelector]
        public AttrAsset primaryEffectedAttribute;
        public float primaryEffect;
        [AttributeSelector]
        public AttrAsset secondaryEffectedAttribute;
        public float secondaryEffect;
        // Start is called before the first frame update
        private void Start()
        {
            this.tag = "Edible";
        }

        public void Consume(Stats stats)
        {
            if (primaryEffectedAttribute != null)
            {
                string primaryID = primaryEffectedAttribute.attribute.uniqueName;
                stats.AddAttrValue(primaryID, this.primaryEffect);
            }

            if (secondaryEffectedAttribute != null)
            {
                string secondaryID = secondaryEffectedAttribute.attribute.uniqueName;
                stats.AddAttrValue(secondaryID, this.secondaryEffect);
            }
            this.gameObject.SetActive(false);
        }

        private float Negative(float num)
        {
            return Mathf.Abs(num) * -1;
        }
    }
}