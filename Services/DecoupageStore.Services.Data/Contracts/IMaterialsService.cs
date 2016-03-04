namespace DecoupageStore.Services.Data.Contracts
{
    using DecoupageStore.Data.Models;
    using System.Linq;

    public interface IMaterialsService
    {
        IQueryable<Material> All();
    }
}
