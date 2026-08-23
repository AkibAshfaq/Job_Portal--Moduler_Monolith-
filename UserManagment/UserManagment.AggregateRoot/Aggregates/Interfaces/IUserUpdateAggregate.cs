
using UserManagment.AggregateRoot.Entities;
using UserManagment.DTO.Command;

namespace UserManagment.AggregateRoot.Aggregates.Interfaces
{
    public interface IUserUpdateAggregate
    {
        Task<User> BindToEntity(User user, UserUpdateCommand request);
    }
}
