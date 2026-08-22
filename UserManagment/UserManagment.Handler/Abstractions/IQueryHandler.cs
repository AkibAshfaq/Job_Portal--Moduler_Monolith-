namespace UserManagment.Handler.Abstractions
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> HandleAsync(TQuery? query);
    }
}
