namespace Field
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.Windows.Speech;
    using GameCreator.Core;
    public class SpeechManager : Singleton<SpeechManager> {
        
        KeywordRecognizer keywordRecognizer;
        // keyword array
        public string[] Keywords_array;
        public UnityEvent<PhraseRecognizedEventArgs> OnPhraseRecognized = new UnityEvent<PhraseRecognizedEventArgs>();
        // Use this for initialization
        void Start () {
            // instantiate keyword recognizer, pass keyword array in the constructor
            keywordRecognizer = new KeywordRecognizer(Keywords_array);
            keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
            // start keyword recognizer
            keywordRecognizer.Start();
        }
    
        void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
        {
            Debug.Log("KEYWORD RECOGNIZED");
            Debug.Log(args.text);
            Debug.Log(args.confidence);
            OnPhraseRecognized.Invoke(args);
            // write your own logic
        }
    }
}