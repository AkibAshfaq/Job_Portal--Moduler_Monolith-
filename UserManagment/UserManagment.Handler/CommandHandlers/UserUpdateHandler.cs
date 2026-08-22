using System;
using System.Collections.Generic;
using System.Text;
using UserManagment.DTO.Command;
using UserManagment.Handler.Abstractions;

namespace UserManagment.Handler.CommandHandlers
{
    public class UserUpdateHandler : ICommandHandler<UserUpdateCommand>
    {


        public async Task HandleAsync(UserUpdateCommand request)
        {
            
        }
    }
}
