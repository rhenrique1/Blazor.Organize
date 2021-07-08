using Organize.Shared.Contracts;
using Organize.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organize.DataAcess
{
    public class ItemDataAcess : IItemDataAccess
    {
        private IPersistanceService _persistanceService;

        public ItemDataAcess(IPersistanceService persistanceService)
        {
            _persistanceService = persistanceService;
        }

        public async Task DeleteItemsAsync<TItem>(IEnumerable<TItem> items) where TItem : BaseItem
        {
            foreach (var item in items)
            {
                await _persistanceService.DeleteAsync<TItem>(item);
            }
        }
        public async Task<IEnumerable<TItem>> GetItemsOfUserAsync<TItem>(int parentId) where TItem : BaseItem
        {
            return await _persistanceService.GetAsync<TItem>(i => i.ParentId == parentId);
        }

        public async Task InsertItemAsync<TItem>(TItem item) where TItem : BaseItem
        {
            var id = await _persistanceService.InsertAsync<TItem>(item);
            item.Id = id;
        }

        public Task UpdateItemAsync<TItem>(TItem item) where TItem : BaseItem
        {
            return _persistanceService.UpdateAsync<TItem>(item);
        }
    }
}
