namespace Field.XR
{
    using Survival;
    using UnityEngine;
    using System.Collections;
    using GameCreator.Variables;
    using GameCreator.Stats;
    using GameCreator.Core;
    [RequireComponent( typeof( BoxCollider ) )]
    public class MouthController : MonoBehaviour
    {
        public TargetCharacter m_CharacterReference;
        public NumberProperty m_FoodProcessRate;
        public NumberProperty m_FoodCounter;
        public GameObjectProperty m_Food;
        public AudioSource m_EatingSound;

        private IEnumerator ProcessFood()
        {
            int counter = (int)m_FoodProcessRate.GetValue(gameObject);
            float delay = m_FoodProcessRate.GetValue(gameObject);
            Debug.Log("It will take us " + counter.ToString() + " seconds to eat this");
            while(counter > 0) {
                Debug.Log("Bite");
                m_EatingSound.Play();
                counter -= 1;
                yield return new WaitForSeconds(delay);
            }

            Debug.Log("Cleaning up...");
            Food food = m_Food.GetValue(gameObject).GetComponent<Food>();
            food.Consume(m_CharacterReference.GetCharacter(gameObject).GetComponent<Stats>());
            m_Food.value = null;
            m_FoodCounter.value = 3;
            Debug.Log("All gone");
            yield return new WaitForFixedUpdate();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name + " is near my mouth!");
            if(m_Food.GetValue(gameObject) == null) {
                Debug.Log("We arent eating anything");
                if(other.CompareTag("Edible")) {
                    Debug.Log("This shit is some food!");
                    m_Food.value = other.gameObject;
                    StartCoroutine(nameof(ProcessFood));
                }   
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(m_Food.GetValue(gameObject) != null) {
                if(other.gameObject == m_Food.GetValue(gameObject)) {
                    m_Food.value = null;
                    StopCoroutine(nameof(ProcessFood));
                }
            }
        }
    }
}