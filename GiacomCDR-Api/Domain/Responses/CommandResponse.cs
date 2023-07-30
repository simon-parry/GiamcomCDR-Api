namespace GiacomCDR_Api.Domain.Responses
{
    public class CommandResponse<T>
    {
        public List<T>? Result { get; set; }
    }

    public class CommandResponseSingle<T>
    {
        public T? Result { get; set; }
    }

    public class CommandResponse_Bool
    {
        public bool Result { get; set; }
    }
}
