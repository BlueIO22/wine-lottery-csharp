using wine_lottery_csharp.Enums;

namespace wine_lottery_csharp.Handlers
{
    public class Response<T>
    {
        public T Data { get; set; }

        public ResponseStatus Status { get; set; } = ResponseStatus.OK;
    }
}
