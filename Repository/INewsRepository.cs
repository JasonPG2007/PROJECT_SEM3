using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface INewsRepository
    {
        IEnumerable<News> GetNewsList(string sortBy);
        IEnumerable<News> GetNewsByName(string name, string sortBy);
        News GetNewsById(int id);
        void InsertNews(News n);
        void EditNews(News n);
        void DeleteNews(int id);

    }
}
