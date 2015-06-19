namespace Labrador.Result
{
    public interface ICommandResult : IResult
    {
        bool Succeeded { get; }
    }
}
