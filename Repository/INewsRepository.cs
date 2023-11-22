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
        void SaveNews(News n);
        void DeleteNews(News n);
        void UpdateNews (News n);
        News GetNewsById(int id);
        List<News> GetAllNews();
    }
}
