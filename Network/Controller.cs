namespace Field.Network
{
    using System;
    using UnityEngine;
    using GameCreator.Variables;
    public class IController : Model { }
    public class NetworkProvider : MonoBehaviour 
    {
        public ListVariables m_Options;
        public LocalVariables m_Data;
        public IController controller;
    }

    public class Controller<DTO> : IController
    {
        public ListVariables m_Options;
        public LocalVariables m_Data;
        public Route index;
        public Route show;
        public Route store;
        public Route patch;
        public Route delete;
        public DTO Process(object data)
        {
            return (DTO)data;
        }
        public void Get(Action<DTO[]> onComplete)
        {
            Client.Instance.Send<DTO[]>((Response<DTO[]> response) =>
            {
                onComplete.Invoke(response.data);
            }, index, new Request());
        }

        public void Show(int ID, Action<DTO> onComplete)
        {
            Client.Instance.Send<DTO>((Response<DTO> response) =>
            {
                onComplete.Invoke(response.data);
            }, show, new Request());
        }

        public void Create(Action<DTO> onComplete)
        {
            Client.Instance.Send<DTO>((Response<DTO> response) =>
            {
                onComplete.Invoke(response.data);
            }, store, new Request());
        }

        public void Patch(DTO current, Action<DTO> onComplete)
        {
            Client.Instance.Send<DTO>((Response<DTO> response) =>
            {
                onComplete.Invoke(response.data);
            }, patch, Request.Arguments(current));
        }

        public void Delete(DTO current, Action<long> onComplete)
        {
            Client.Instance.Send<DTO>((Response<DTO> response) =>
            {
                onComplete.Invoke(response.response.StatusCode);
            }, delete, Request.Arguments(current));
        }
    }
}