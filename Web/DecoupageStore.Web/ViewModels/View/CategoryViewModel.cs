﻿namespace DecoupageStore.Web.ViewModels.View
{
    using Data.Models;
    using DecoupageStore.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}