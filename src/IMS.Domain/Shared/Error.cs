namespace IMS.Domain.Shared;
public class Error
{
    public static Error None = new(string.Empty, string.Empty);

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; private set; }
    public string Message { get; private set; }
}
