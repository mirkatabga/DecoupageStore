namespace DecoupageStore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using DecoupageStore.Data.Models;

    public interface IProductsService
    {
        List<Product> GetProducts(int page, int count);
    }
}
