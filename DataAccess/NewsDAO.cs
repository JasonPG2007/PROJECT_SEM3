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

        ////------------- MVC ----------------------//////
        /*        public IEnumerable<News> GetNewsList(string sortBy)
                {
                    using var context = new PetroleumBusinessDBContext();
                    List<News> model = context.News.ToList();
                    try
                    {
                        switch (sortBy)
                        {
                            case "name":
                                model = model.OrderBy(o => o.Title).ToList();
                                break;
                            case "namedesc":
                                model = model.OrderByDescending(o => o.Title).ToList();
                                break;
                            case "id":
                                model = model.OrderBy(o => o.NewsID).ToList();
                                break;
                            case "iddesc":
                                model = model.OrderByDescending(o => o.NewsID).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return model;
                }

                public News GetNewsById(int id)
                {
                    News n = null;
                    try
                    {
                        using var context = new PetroleumBusinessDBContext();
                        n = context.News.FirstOrDefault(k => k.NewsID == id);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return n;
                }

                public IEnumerable<News> GetNewsBySearchName(string name, string sortBy)
                {
                    var context = new PetroleumBusinessDBContext();
                    List<News> model = context.News.ToList();

                    try
                    {
                        if (!String.IsNullOrEmpty(name))
                        {
                            model = model.Where(x => x.Title.ToLower().Contains(name)).ToList();
                        }
                        switch (sortBy)
                        {
                            case "name":
                                model = model.OrderBy(o => o.Title).ToList();
                                break;
                            case "namedesc":
                                model = model.OrderByDescending(o => o.Title).ToList();
                                break;
                            case "id":
                                model = model.OrderBy(o => o.NewsID).ToList();
                                break;
                            case "iddesc":
                                model = model.OrderByDescending(o => o.NewsID).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return model;
                }

                // Add News
                public void InsertNews(News n)
                {

                    try
                    {
                        News _n = GetNewsById(n.NewsID);
                        if (_n == null)
                        {
                            using var context = new PetroleumBusinessDBContext();
                            context.News.Add(n);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("This News is already exist.");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                // Edit News
                public void EditNews(News n)
                {

                    try
                    {
                        News _n = GetNewsById(n.NewsID);
                        if (_n != null)
                        {
                            using var context = new PetroleumBusinessDBContext();
                            context.News.Update(n);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("This News does not already exist.");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                public void DeleteNews(int id)
                {
                    try
                    {
                        News _n = GetNewsById(id);
                        if (_n != null)
                        {
                            using var context = new PetroleumBusinessDBContext();
                            context.News.Remove(_n);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("This News does not already exist.");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }*/


        ///////////////////////////////////////---2-----//////////////////////////////////////////////////////////////////
        public static List<News> GetNewsList()
        {
            var list = new List<News>();
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    list = context.News.ToList();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
            return list;
        }

        public static News GetNewsById(int id)
        {
            News n = new News();
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    n = context.News.FirstOrDefault(x => x.NewsID == id);
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return n;
        }

        public static void InsertNews(News n)
        {
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    context.News.Add(n);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EditNews(News n)
        {
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    context.Entry<News>(n).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                };
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
                    var _n = context.News.SingleOrDefault(x => x.NewsID == n.NewsID);
                    context.News.Remove(_n);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
