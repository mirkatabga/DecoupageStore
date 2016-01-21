namespace DecoupageStore.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class DecoupageStoreDbContext : IdentityDbContext<User>, IDecoupageStoreDbContext
    {
        public DecoupageStoreDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static DecoupageStoreDbContext Create()
        {
            return new DecoupageStoreDbContext();
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductImage> ProductImages { get; set; }
    }
}
