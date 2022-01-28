namespace Field.Network
{
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.Events;
    using System;
    using RSG;
    public interface IPersist
    {
        public IPromise Get();
        public IPromise Load();
        public IPromise Save();
    }
    [Serializable]
    public abstract class Persist<DTO> : MonoBehaviour, IPersist
    {
        //Options Route config
        [SerializeField] public Route m_OptionRouter;
        //Load Route config
        [SerializeField] public Route m_LoadRouter;
        //Save Route config
        [SerializeField] public Route m_SaveRouter;
        //List of IDs
        [SerializeField] public string[] m_Options;
        //The current Model ID
        [SerializeField] public string current;
        public UnityEvent<Response<object>> OnSaveEvent = new UnityEvent<Response<object>>();
        //Should load up on start
        public bool lazyLoad = true;
        //Track if the options array is populated
        private bool initialLoad = false;
        //Loaded records
        private DTO[] m_Records;
        //Define how the data is handled when loaded
        public abstract void OnLoad(DTO response);
        //Define form data for persisting records
        public abstract Request OnSave();
        //Bootstrap the client and get the model options (Usually an array of IDs)
        public virtual void Start()
        {
            if (!this.lazyLoad)
            {
                this.Initialize();
            }
        }

        private void Initialize()
        {
            Client.Instance.Send<string[]>((Response<string[]> response) =>
            {
                Debug.Log(response.response.Text);
                this.m_Options = response.data;
            }, this.m_OptionRouter);
            this.initialLoad = true;
        }
        [Button("Get")]
        public IPromise Get()
        {
            var response = Client.Instance.Send<DTO[]>((Response<DTO[]> response) =>
            {
                m_Records = response.data;
            }, m_LoadRouter, new Request());
            return response;
        }
        //Load the data via the LoadRouter
        [Button("Load")]
        public IPromise Load()
        {
            if (!this.initialLoad) { this.Initialize(); }
            var request = new Request().Next("index", this.current);
            var response = Client.Instance.Send<DTO>((Response<DTO> response) =>
            {
                this.OnLoad(response.data);
            }, m_LoadRouter, request);
            return response;
        }
        //Persist the data via the SaveRouter
        [Button("Save")]
        public IPromise Save()
        {
            if (!this.initialLoad) { this.Initialize(); }
            return Client.Instance.Send((Response<object> response) =>
            {
                this.OnSaveEvent.Invoke(response);
            }, this.m_SaveRouter, this.OnSave());
        }
    }
}