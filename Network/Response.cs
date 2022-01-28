namespace Field.Network
{
    using Proyecto26;
    using Newtonsoft.Json;
    public interface IResponse {}
    public class Response<T> : IResponse
    {
        public T data;
        public ResponseHelper response;
        public Response(ResponseHelper helper)
        {
            this.data = JsonConvert.DeserializeObject<T>(helper.Text);
            this.response = helper;
        }
    }
}