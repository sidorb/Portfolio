namespace Portfolio.Web.Migrations
{
    using Portfolio.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Portfolio.Web.Infrastructure.PortfolioDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Portfolio.Web.Infrastructure.PortfolioDb context)
        {
            context.Categories.AddOrUpdate(
                    c => c.Name,
                    new Category { Name = "booklets / calendar" },
                    new Category { Name = "logos / pictograms" },
                    new Category { Name = "illustration" }
                );

            context.Pictures.AddOrUpdate(
                    p => p.ImageUrl,
                    new Picture { 
                        ImageUrl = "http://static.wix.com/media/a5380d_21a5d5d8c35dd5b7119e5b08469a11a0.jpg_srz_714_739_85_22_0.50_1.20_0.00_jpg_srz",
                        Description = "Pistols",
                        CategoryId = 1
                    },
                    
                    new Picture {
                        ImageUrl = "http://static.wix.com/media/a5380d_af6b8f90d72ba16053abc94cec690c4f.jpg_srz_444_361_85_22_0.50_1.20_0.00_jpg_srz",
                        Description = "Pistols calendar",
                        CategoryId = 1
                    });
        }
    }
}
