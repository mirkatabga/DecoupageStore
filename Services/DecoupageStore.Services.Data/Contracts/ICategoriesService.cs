using System.Linq;
using DecoupageStore.Data.Models;

namespace DecoupageStore.Services.Data.Contracts
{
    public interface ICategoriesService
    {
        IQueryable<Category> All();
    }
}
