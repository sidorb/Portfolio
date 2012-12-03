using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain
{
    public interface IPortfolioDataSource
    {
        IQueryable<Picture> Pictures { get; }
        IQueryable<Category> Categories { get; }
        void Save();
        void AddCategory(Category category);
        void AddPicture(Picture picture);
        void DeleteCategory(int id);
        void DeletePicture(int id);
    }
}
