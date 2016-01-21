namespace DecoupageStore.Web
{
    using Data;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DecoupageStoreDbContext>());
        }
    }
}