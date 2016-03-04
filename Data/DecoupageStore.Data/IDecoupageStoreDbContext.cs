namespace DecoupageStore.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IDecoupageStoreDbContext
    {
        IDbSet<Product> Products { get; set; }

        IDbSet<ProductImage> ProductImages { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Material> Materials { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
