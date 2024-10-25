using BussinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public ObservableCollection<Category> GetCategories() => CategoryDAO.GetCategories();
    }
}
