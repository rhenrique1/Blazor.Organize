using Organize.Shared.Contracts;
using Organize.Shared.Entities;
using Organize.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organize.Business
{
    public class UserItemManager : IUserItemManager
    {
        public async Task<ChildItem> CreateNewChildItemAndAddItToParentItemAsync(ParentItem parent)
        {
            var childItem = new ChildItem();
            childItem.ParentId = parent.Id;
            childItem.ItemTypeEnum = ItemTypeEnum.Child;

            parent.ChildItems.Add(childItem);
            return await Task.FromResult(childItem);
        }

        private async Task<T> CreateAndInsertItemsAsync<T>(User user, ItemTypeEnum typeEnum) where T : BaseItem, new()
        {
            var item = new T();
            item.ItemTypeEnum = typeEnum;
            item.Position = user.UserItems.Count + 1;
            item.ParentId = user.Id;

            return await Task.FromResult(item);
        }

        public async Task<BaseItem> CreateNewUserItemAndAddItToUserAsync(User user, ItemTypeEnum typeEnum)
        {
            BaseItem item = null;
            switch (typeEnum)
            {
                case ItemTypeEnum.Text:
                    item = await CreateAndInsertItemsAsync<TextItem>(user, typeEnum);
                    break;
                case ItemTypeEnum.Url:
                    item = await CreateAndInsertItemsAsync<UrlItem>(user, typeEnum);
                    break;
                case ItemTypeEnum.Parent:
                    var parent = await CreateAndInsertItemsAsync<ParentItem>(user, typeEnum);
                    parent.ChildItems = new ObservableCollection<ChildItem>();
                    item = parent;
                    break;
            }

            user.UserItems.Add(item);
            return item;
        }
    }
}
