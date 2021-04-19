using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataStorage;
using lab1_1;

namespace Services
{
    class CategoryService
    {
        private FileDataStorage<Category> _storage = new FileDataStorage<Category>();



        public async Task<bool> AddOrUpdateCategoryAsync(Category category)
        {
            Thread.Sleep(1000);
            await Task.Run(() => _storage.AddOrUpdate(category));
            return true;
        }


        public void DeleteCategory(Category category)
        {
            Thread.Sleep(1000);
            _storage.Delete(category);
        }


        public List<Category> GetCategories()
        {
            Task<List<Category>> categories = Task.Run<List<Category>>(async () => await _storage.GetAllAsync());
            return categories.Result;
        }
    }
}
