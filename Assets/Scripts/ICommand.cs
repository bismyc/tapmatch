public interface ICommand
{
    void Execute();
    bool IsComplete { get; }
}
