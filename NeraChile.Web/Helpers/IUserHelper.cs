﻿using Microsoft.AspNetCore.Identity;
using NeraChile.Web.Entities;
using NeraChile.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Helpers
{
        public interface IUserHelper
        {
            Task<User> GetUserByEmailAsync(string email);
            Task<IdentityResult> AddUserAsync(User user, string password);
            Task CheckRoleAsync(string roleName);
            Task AddUserToRoleAsync(User user, string roleName);
            Task<bool> IsUserInRoleAsync(User user, string roleName);
            Task<SignInResult> LoginAsync(LoginViewModel model);
            Task LogoutAsync();
            Task<IdentityResult> UpdateUserAsync(User user);
            Task<bool> DeleteUserAsync(string email);
            

        }
}
