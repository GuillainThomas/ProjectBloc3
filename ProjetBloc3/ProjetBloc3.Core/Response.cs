namespace ProjetBloc3.Core
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool IsSuccesful { get; set; }
        public string? Message { get; set; }

        public Response(T data)
        {
            this.Data = data;
            this.IsSuccesful = true;
        }

        public Response(string message)
        {
            this.Message = message;
            this.IsSuccesful = false;
        }
    }
}
