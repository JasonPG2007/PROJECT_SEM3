using DataAccess;
using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NewsRepository: INewsRepository
    {
        public void SaveNews (News n) => NewsDAO.SaveNews (n);
        public void UpdateNews (News n) => NewsDAO .UpdateNews (n);
        public void DeleteNews (News n) => NewsDAO.DeleteNews (n);
        public News GetNewsById (int id) => NewsDAO.FindNewsById (id);
        public List<News> GetAllNews() => NewsDAO.GetAllNews ();
        public List<NewsCategory> GetAllNewsCategories() => NewsCategoryDAO.GetNewsCategories ();
    }
}
