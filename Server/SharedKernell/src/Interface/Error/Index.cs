namespace SharedKernell.src.Interface.Error;

public interface IError
{
    public string Message { get; }
    public string Type { get; }
}

public interface IAppError
{
    public int Code { get; }
    public string Message { get; }
}