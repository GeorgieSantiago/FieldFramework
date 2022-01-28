namespace Field.Network
{
    using System;
    using Proyecto26;
    using UnityEngine;
    using Sirenix.OdinInspector;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public class Args : Dictionary<string, string> { }
    public class Route : ScriptableObject
    {
        [BoxGroup("URL")]
        [SerializeField]
        public string m_BaseUrl = "https://random-data-api.com/api/stripe/random_stripe";
        [BoxGroup("URL")]
        [SerializeField]
        public int m_ID = -1;
        [BoxGroup("Parameters")]
        [SerializeField]
        public HTTP_VERB m_httpVerb;
        [BoxGroup("Parameters")]
        [SerializeField]
        public Args m_QueryParameters = new Args();
        [BoxGroup("Request Variables")]
        [SerializeField]
        public Args requestVariables = new Args();
        [BoxGroup("Request Variables")]
        [SerializeField]
        public Args responseVariables = new Args();
    }
}
