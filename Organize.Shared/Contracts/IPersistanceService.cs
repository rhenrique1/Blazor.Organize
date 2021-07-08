﻿using Organize.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Organize.Shared.Contracts
{
    public interface IPersistanceService
    {
        Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> whereExpression) where T : BaseEntity;
        Task<int> InsertAsync<T>(T entity) where T : BaseEntity;
        Task UpdateAsync<T>(T entity) where T : BaseEntity;
        Task InitAsync();
        Task<User> AuthenticateAndGetUserAsync(User user);
        Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}
