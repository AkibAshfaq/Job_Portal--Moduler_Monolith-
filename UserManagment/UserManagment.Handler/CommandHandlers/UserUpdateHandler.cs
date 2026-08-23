using UserManagment.AggregateRoot.Aggregates.Interfaces;
using UserManagment.DTO.Command;
using UserManagment.Handler.Abstractions;
using UserManagment.Repository.Repositories.Interfaces;

namespace UserManagment.Handler.CommandHandlers
{
    public class UserUpdateHandler : ICommandHandler<UserUpdateCommand>
    {
        private readonly IUserRepository _userRepo;
        public UserUpdateHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        private readonly IUserUpdateAggregate _userUpdateAgg;

        public UserUpdateHandler(IUserRepository userRepo, IUserUpdateAggregate userUpdateAgg)
        {
            _userRepo = userRepo;
            _userUpdateAgg = userUpdateAgg;
        }

        public async Task HandleAsync(UserUpdateCommand command)
        {
            var user = _userRepo.GetUserByEmail(command.Email);
            if (user == null && user.FullName != command.FullName)
                throw new InvalidOperationException("User doesn't exists.");

            var newUser= _userUpdateAgg.BindToEntity(user, command);
            _userRepo.Update(newUser.Result);
            await _userRepo.SaveChangeAsync();
        }
    }
}
