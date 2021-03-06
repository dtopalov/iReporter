﻿namespace IReporter.Web.ViewModels.Home
{
    using IReporter.Data.Models;
    using IReporter.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
