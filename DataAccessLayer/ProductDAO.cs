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
    public class ProductDAO
    {
        //private static ProductDAO instance = null;
        //private static readonly object instanceLock = new object();
        public static ObservableCollection<Product> listProducts;

        public static ObservableCollection<Product> GetProducts()
        {
            var listProducts = new ObservableCollection<Product>();
            try
            {
                using var db = new ProductStore();
                var products = db.Products.ToList();
                listProducts = new ObservableCollection<Product>(products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProducts;
        }

        public static Product GetProductById(int id)
        {
            using var db = new ProductStore();
            return db.Products.FirstOrDefault(c => c.ProductId.Equals(id));
        }

        public static void SaveProduct(Product p)
        {
            try
            {
                using var context = new ProductStore();
                context.Products.Add(p);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateProduct(Product p)
        {
            try
            {
                using var context = new ProductStore();
                context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteProduct(Product p)
        {
            try
            {
                using var context = new ProductStore();
                var p1 = context.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                context.Products.Remove(p1);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
