using BussinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.ProductStoreContext;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        public static IEnumerable<Category> GetCategories()
        {
            IEnumerable<Category> listCategories = null;
            try {
                using var context = new ProductStore();
                listCategories = context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCategories;
        }


    }
}
