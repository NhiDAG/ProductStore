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
        public static ObservableCollection<Category> GetCategories()
        {
            var listCategories = new ObservableCollection<Category>();
            try {
                using var context = new ProductStore();
                var categories = context.Categories.ToList();
                listCategories = new ObservableCollection<Category>(categories);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCategories;
        }
    }
}
