using SharedKernell.src.Interface.Error;

namespace SharedKernell.src.Interface.Result;

public interface IResult
{
    public bool IsSuccess { get; }
    public bool IsFailure { get; }
    public IError Error { get; }
}