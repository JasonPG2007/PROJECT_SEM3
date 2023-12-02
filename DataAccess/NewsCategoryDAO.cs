using Microsoft.EntityFrameworkCore;
using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NewsCategoryDAO
    {
        private static NewsCategoryDAO instance = null;
        public static readonly object instanceLock = new object();
        public static NewsCategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NewsCategoryDAO();
                    }
                    return instance;
                }
            }
        }

        //Get News Category
        public static List<NewsCategory> GetNewsCategories()
        {
            var list = new List<NewsCategory>();
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    list = context.NewsCategories.ToList();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
            return list;
        }
    }
}
