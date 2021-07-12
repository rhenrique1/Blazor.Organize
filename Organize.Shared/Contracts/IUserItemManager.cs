﻿using Organize.Shared.Entities;
using Organize.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organize.Shared.Contracts
{
    public interface IUserItemManager
    {
        Task<ChildItem> CreateNewChildItemAndAddItToParentItemAsync(ParentItem parent);
        Task<BaseItem> CreateNewUserItemAndAddItToUserAsync(User user, ItemTypeEnum typeEnum);
        Task RetrieveAllUserItemsOfUserAndSetToUserAsync(User user);
        Task UpdateAsync<T>(T item) where T : BaseItem;
        Task DeleteAllDoneAsync(User user);
    }
}
