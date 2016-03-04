namespace DecoupageStore.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using DecoupageStore.Data.Models;
    using DecoupageStore.Data.Repositories;

    public class CategoriesService : ICategoriesService
    {
        private IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IQueryable<Category> All()
        {
            return categoriesRepository.All();
        }
    }
}
