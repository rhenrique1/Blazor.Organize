using Microsoft.JSInterop;
using Newtonsoft.Json;
using Organize.Shared.Contracts;
using Organize.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Organize.IndexedDb
{
    public class IndexedDb : IPersistanceService
    {
        private IJSRuntime _jsRuntime;
        private JsonSerializerSettings _settings;

        public IndexedDb(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
            _settings = new JsonSerializerSettings();
            _settings.ContractResolver = new ContractResolver();
        }
        public Task<User> AuthenticateAndGetUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            var tableName = typeof(T).Name;
            await _jsRuntime.InvokeVoidAsync("organizeIndexedDB.deleteAsync", tableName, entity.Id);
        }

        public async Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> whereExpression) where T : BaseEntity
        {
            var tableName = typeof(T).Name;

            var entities = await _jsRuntime.InvokeAsync<T[]>("organizeIndexedDB.getAllAsync", tableName);
            return entities.Where(whereExpression.Compile());
        }

        public async Task InitAsync()
        {
            await _jsRuntime.InvokeVoidAsync("organizeIndexedDB.initAsync");
        }

        public async Task<int> InsertAsync<T>(T entity) where T : BaseEntity
        {
            var tableName = typeof(T).Name;
            var serializedEntity = SerializeAndRemoveArraysAndNavigationProperties(entity);

            var id = await _jsRuntime.InvokeAsync<int>("organizeIndexedDB.addAsync", tableName, serializedEntity);
            return id;
        }

        private string SerializeAndRemoveArraysAndNavigationProperties<T>(T entity)
        {
            return JsonConvert.SerializeObject(entity, _settings);
        }

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            var tableName = typeof(T).Name;
            Console.WriteLine(tableName);
            var serializedEntity = SerializeAndRemoveArraysAndNavigationProperties(entity);
            await _jsRuntime.InvokeVoidAsync("organizeIndexedDB.putAsync", tableName, serializedEntity, entity.Id);
        }
    }
}
