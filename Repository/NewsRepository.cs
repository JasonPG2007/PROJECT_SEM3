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
        // --MVC-- //
        /* public IEnumerable<News> GetNewsList(string sortBy) => NewsDAO.Instance.GetNewsList(sortBy);
         public IEnumerable<News> GetNewsByName(string name, string sortBy) => NewsDAO.Instance.GetNewsBySearchName(name, sortBy);

         public News GetNewsById(int id) => NewsDAO.Instance.GetNewsById(id);
         public void InsertNews(News n) => NewsDAO.Instance.InsertNews(n);
         public void EditNews(News n) => NewsDAO.Instance.EditNews(n);
         public void DeleteNews(int id) => NewsDAO.Instance.DeleteNews(id);*/

        // --API-- //

        public void InsertNews(News n) => NewsDAO.InsertNews(n);
        public void EditNews(News n) => NewsDAO.EditNews(n);
        public void DeleteNews(News n) => NewsDAO.DeleteNews(n);
        public News GetNewsById(int id) => NewsDAO.GetNewsById(id);
        public List<NewsCategory> GetNewsCategories() => NewsCategoryDAO.GetNewsCategories();
        public List<News> GetNewsList() => NewsDAO.GetNewsList();
    }
}
