namespace Field.Network
{
    using System;
	using System.Reflection;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using GameCreator.Core;
    using GameCreator.Variables;
    using Proyecto26;
    using RSG;
    using Sirenix.OdinInspector;
    using Newtonsoft.Json;

    public enum HTTP_VERB
    {
        GET,
        POST,
        PATCH,
        DELETE
    }

    [AddComponentMenu("")]
    public class Fetch : IAction
    {
        [BoxGroup("URL")]
        public StringProperty m_BaseUrl = new StringProperty("https://random-data-api.com/api/stripe/random_stripe");
        [BoxGroup("URL")]
        public NumberProperty m_ID = new NumberProperty(-1);
        [BoxGroup("Parameters")]
        public Args m_QueryParameters = new Args();
        [BoxGroup("Parameters")]
        public HTTP_VERB m_httpVerb;
        [BoxGroup("Request Variables")]
        public GameObjectProperty requestVariables;
        [BoxGroup("Request Variables")]
        public GameObjectProperty responseVariables;
        [BoxGroup("Config")]
        public NumberProperty progress;
        public Type type;
        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            var arguments = requestVariables
              .GetValue();
            var form = arguments != null
                ? JsonConvert.SerializeObject(
                    arguments.TryGetComponent(out LocalVariables request)
                  )
                : new object();
            string id = this.m_ID.GetValue(gameObject) > -1 ? this.m_ID.GetValue().ToString() : "";
            var url = this.m_BaseUrl.GetValue(gameObject) + id;
            RestClient.Request(new RequestHelper
            {
                Uri = url,
                Method = this.m_httpVerb.ToString(),
                Timeout = 10,
                Params = this.m_QueryParameters,
                Headers = new Dictionary<string, string> {
                    { "Authorization", "Bearer JWT_token..." }
                },
                Body = form, //Content-Type: application/x-www-form-urlencoded
                ContentType = "application/json", //JSON is used by default
                Retries = 3, //Number of retries
                RetrySecondsDelay = 2, //Seconds of delay to make a retry
                RetryCallbackOnlyOnNetworkErrors = true, //Invoke RetryCallack only when the retry is provoked by a network error
                RetryCallback = (err, retries) => { }, //See the error before retrying the request
                ProgressCallback = (percent) => { }, //Reports progress of the request from 0 to 1
                EnableDebug = true, //See logs of the requests for debug mode
                IgnoreHttpException = true, //Prevent to catch http exceptions
                UseHttpContinue = true,
                RedirectLimit = 32,
                DefaultContentType = false, //Disable JSON content type by default
                ParseResponseBody = false //Don't encode and parse downloaded data as JSON
            }).Then(response =>
            {
				var responseVars = responseVariables.GetValue(gameObject);
				if(responseVars != null) 
				{
					responseVars.TryGetComponent(out LocalVariables data);
					if(data != null)
					{
						VariablesManager.SetLocal(responseVars, "response", response.Text);
						VariablesManager.SetLocal(responseVars, "status", response.StatusCode);   
					}
				}
				
            }).Catch(err =>
            {
                var error = err as RequestException;
				var responseVars = responseVariables.GetValue(gameObject);
				if(responseVars != null) 
				{
					responseVars.TryGetComponent(out LocalVariables data);
					if(data != null)
					{
						VariablesManager.SetLocal(responseVars, "response", err.Message);
						VariablesManager.SetLocal(responseVars, "status", err.Data.ToString());
					}
				}
            });
            return true;
        }
#if UNITY_EDITOR
        public static new string NAME = "Field/Network/Fetch";
#endif
    }
}
