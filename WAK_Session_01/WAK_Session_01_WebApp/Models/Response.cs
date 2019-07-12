namespace WAK_Session_01_WebApp.Models
{
    public class Response<T>
    {
        public T Result { get; set; }

        public Response(T val)
        {
            Result = val;
        }
    }
}
