using JobPortal.Shared.Interfaces.QueryHandler;
using UserManagement.AggregateRoot;
using UserManagement.DTO.Query;
using UserManagement.Repository.Repositories.Interfaces;

namespace UserManagement.Handler.QueryHandler
{
    public class GetUsersHandler: IQueryHandler<GetUsersQuery, IEnumerable<UsersAggregateRoot>>
    {
        private readonly IUserRepository _userRepo;

        public GetUsersHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<UsersAggregateRoot>> HandleAsync(GetUsersQuery query)
        {
            try
            {
                var users = await _userRepo.GetAllAsync();
                return users;
            }
            catch (Exception)
            {
                throw new InvalidDataException("An error occurred while retrieving users.");
            }

        }

    }
}
