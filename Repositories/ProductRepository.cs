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
    public class ProductRepository : IProductRepository
    {
        public void SaveProduct(Product p) => ProductDAO.SaveProduct(p);
        public void UpdateProduct(Product p) => ProductDAO.UpdateProduct(p);
        public void DeleteProduct(Product p) => ProductDAO.DeleteProduct(p);
        public IEnumerable<Product> GetProducts() => ProductDAO.GetProducts();
        public Product GetProductById(int id)=> ProductDAO.GetProductById(id);
    }
}
