namespace DecoupageStore.Services.Data
{
    using Contracts;
    using DecoupageStore.Data.Models;
    using DecoupageStore.Data.Repositories;
    using System.Linq;

    public class MaterialsService : IMaterialsService
    {
        private IRepository<Material> materialsRepository;

        public MaterialsService(IRepository<Material> materialsRepository)
        {
            this.materialsRepository = materialsRepository;
        }

        public IQueryable<Material> All()
        {
            return this.materialsRepository.All();
        }
    }
}
