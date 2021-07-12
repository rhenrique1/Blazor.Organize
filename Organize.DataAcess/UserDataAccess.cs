using Organize.Shared.Contracts;
using Organize.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organize.DataAcess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly IPersistanceService _persistanceService;

        public UserDataAccess(IPersistanceService persistanceService)
        {
            _persistanceService = persistanceService;
        }

        public async Task<bool> IsUserWithNameAvailableAsync(User user)
        {
            var users = await _persistanceService.GetAsync<User>(u => u.UserName == user.UserName);
            return users.FirstOrDefault() != null;
        }

        public async Task InsertUserAsync(User user)
        {
            await _persistanceService.InsertAsync(user);
        }

        public async Task<User> AuthenticateAndGetUserAsync(User user)
        {
            var users = await _persistanceService.GetAsync<User>(u => u.UserName == user.UserName && user.Password == u.Password);

            return users.FirstOrDefault();
        }
    }
}
