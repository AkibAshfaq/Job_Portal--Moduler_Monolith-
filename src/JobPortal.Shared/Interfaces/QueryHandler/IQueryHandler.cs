namespace JobPortal.Shared.Interfaces.QueryHandler
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
