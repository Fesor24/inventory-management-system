using IMS.Domain.Shared;

namespace IMS.API.Shared;

public class ApiResponse
{
    public bool IsSuccess { get; private set; }

    public Error Error { get; private set; }

    public ApiResponse()
    {
        IsSuccess = true;
    }

    public ApiResponse(Error error)
    {
        IsSuccess = false;
        Error = error;
    }
}

public class ApiResponse<TData> : ApiResponse
{
    public ApiResponse(TData data) : base()
    {
        Data = data;
    }

    public TData Data { get; private set; }
}
