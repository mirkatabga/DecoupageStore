namespace DecoupageStore.Web.ViewModels.View
{
    using DecoupageStore.Data.Models;
    using DecoupageStore.Web.Infrastructure.Mapping;

    public class MaterialViewModel : IMapFrom<Material>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}