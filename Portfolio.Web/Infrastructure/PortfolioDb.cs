using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portfolio.Domain;
using System.Data.Entity;

namespace Portfolio.Web.Infrastructure
{
    public class PortfolioDb : DbContext, IPortfolioDataSource
    {
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Category> Categories { get; set; }

        IQueryable<Picture> IPortfolioDataSource.Pictures
        {
            get { return Pictures; }
        }

        IQueryable<Category> IPortfolioDataSource.Categories
        {
            get { return Categories; }
        }

        void IPortfolioDataSource.Save()
        {
            SaveChanges();
        }

        void IPortfolioDataSource.AddCategory(Category category)
        {
            if (category.CategoryId != 0)
            {
                var entry = Categories.Find(category.CategoryId);
                Entry<Category>(entry).CurrentValues.SetValues(category);
                
                SaveChanges();
                return;
            }
            
            Categories.Add(category);
            SaveChanges();
        }

        void IPortfolioDataSource.AddPicture(Picture picture)
        {
            if (picture.PictureId!= 0)
            {
                var entry = Pictures.Find(picture.PictureId);
                Entry<Picture>(entry).CurrentValues.SetValues(picture);

                SaveChanges();
                return;
            }

            Pictures.Add(picture);
            SaveChanges();
        }

        void IPortfolioDataSource.DeleteCategory(int id)
        {
            Categories.Remove(Categories.Single(c => c.CategoryId == id));
            SaveChanges();
        }

        void IPortfolioDataSource.DeletePicture(int id)
        {
            Pictures.Remove(Pictures.Single(p => p.PictureId == id));
            SaveChanges();
        }
    }
}