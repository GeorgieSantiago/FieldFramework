namespace Field.Network
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using UnityEngine;
    using Models;
    using Newtonsoft.Json;
    using Proyecto26;
    using RSG;
#if UNITY_EDITOR
    using UnityEditor;
#endif
    public struct NetworkError
    {
        public string errorName;
        public string errorDescription;
    }

    public class Request : Dictionary<string, string>
    {
        public static Request Arguments(Dictionary<string, string> dict)
        {
            var request = new Request();
            foreach (KeyValuePair<string, string> d in dict)
            {
                request.Add(d.Key, d.Value.ToString());
            }

            return request;
        }

        public static Request Arguments<T>(T target)
        {
            PropertyInfo[] props = target.GetType().GetProperties();
            var request = new Request();
            foreach (PropertyInfo prop in props)
            {
                request.Next(prop.Name, prop.GetValue(target));
            }

            return request;
        }
        public Request Next(string key, object value)
        {
            this.Add(key, value.ToString());
            return this;
        }
    }

    public class Client : MonoBehaviour
    {
//        public NetworkConfiguration config;
        public bool debug;
        public bool offline = false;
        public static Client Instance;
        public string baseURL;
        public HTTP_VERB type;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
//            this.config.headers.Add("X-Field-Header", SystemInfo.deviceUniqueIdentifier);
        }

        public IPromise Send<T>(Action<Response<T>> callback, Route route)
        {
            var request = new Request();
            return this.Send<T>(callback, route, request);
        }

        public IPromise Send<T>(Action<Response<T>> callback, Route route, Request args)
        {
            try
            {
                return RestClient.Request(new RequestHelper
                {
                    Uri = this.baseURL,
                    Method = type.ToString(),
                    Timeout = 10,
                    Params = args,
                    Headers = new Dictionary<string, string>() {
                        
                    }
                })
                .Then(response =>
                {
                    Debug.Log(JsonConvert.SerializeObject(response));
                    callback.Invoke(new Response<T>(response));
                }).Catch(err =>
                {
                    var error = err as RequestException;
                    Debug.Log(error);
                    Debug.Log(error.Message);
                    Debug.Log(error.Response);
                    Debug.Log(JsonConvert.SerializeObject(error));
                    EditorUtility.DisplayDialog("Error Response", error.Message, "Ok");
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}