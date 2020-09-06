using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flowmaker.models;

namespace flowmaker.app.Services
{
    public class MockDataStore : IDataStore<Flow>
    {
        readonly List<Flow> items;

        public MockDataStore()
        {
            items = new List<Flow>()
            {
                new Flow { Id = Guid.NewGuid(), Name = "First item", Title="This is an item description." },
                new Flow { Id = Guid.NewGuid(), Name = "Second item", Title="This is an item description." },
                new Flow { Id = Guid.NewGuid(), Name = "Third item", Title="This is an item description." },
                new Flow { Id = Guid.NewGuid(), Name = "Fourth item", Title="This is an item description." },
                new Flow { Id = Guid.NewGuid(), Name = "Fifth item", Title="This is an item description." },
                new Flow { Id = Guid.NewGuid(), Name = "Sixth item", Title="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Flow item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Flow item)
        {
            var oldItem = items.Where((Flow arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var oldItem = items.Where((Flow arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Flow> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Flow>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}