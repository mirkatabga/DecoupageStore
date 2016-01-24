namespace DecoupageStore.Web
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DecoupageStoreDbContext, Configuration>());
        }
    }
}