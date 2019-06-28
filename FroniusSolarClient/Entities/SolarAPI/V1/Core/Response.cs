namespace FroniusSolarClient.Entities.SolarAPI.V1
{
    public class Response<T>
    {
        public CommonResponseHeader Head { get; set; }

        public ResponseBody<T> Body { get; set; }
    }
}