namespace DecoupageStore.Services.Data.Contracts
{
    using DecoupageStore.Data.Models;
    using System.Linq;

    public interface IProductsService
    {
        IQueryable<Product> GetProducts(int page, int count);

        Product GetById(int id);

        IQueryable<Product> Search(string query, int categoryId);
    }
}
