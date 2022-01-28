namespace Field
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
    using GameCreator.Variables;
    using GameCreator.Core;
    using UnityEngine.Windows.Speech;
    [AddComponentMenu("")]
    public class OnSpeechRecognized : Igniter 
	{
		#if UNITY_EDITOR
        public new static string NAME = "Field/Keyword Recognized";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
        #endif
        public StringProperty keyword;

        private void Start()
        {
            SpeechManager.Instance.OnPhraseRecognized.AddListener((PhraseRecognizedEventArgs args) => {
                if(args.text == keyword.GetValue(gameObject)) {
                    this.ExecuteTrigger(gameObject);
                }
            });
        }
	}
}