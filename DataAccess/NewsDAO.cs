using Microsoft.EntityFrameworkCore;
using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NewsDAO
    {
        private static NewsDAO instance = null;
        public static  readonly object instanceLock = new object();
        public static NewsDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NewsDAO();
                    }
                    return instance;
                }
            }
        }
        public static News FindNewsById(int id)
        {
            News n = new News();
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    n = context.News.FirstOrDefault(x => x.NewsID == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return n;
        }
        public static List<News> GetAllNews()
        {
            var list = new List<News>();
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    list = context.News.ToList();
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static void SaveNews(News n)
        {
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    context.News.Add(n);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateNews(News n)
        {
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    context.Entry<News>(n).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteNews(News n)
        {
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    var n1 = context.News.SingleOrDefault(x => x.NewsID == n.NewsID);
                    context.News.Remove(n1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
