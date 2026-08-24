namespace JobPortal.Shared.Interfaces.CommandHandler
{
    public interface ICommandHandler<TCommand>
    {
        Task HandleAsync(TCommand command);
    }
}
