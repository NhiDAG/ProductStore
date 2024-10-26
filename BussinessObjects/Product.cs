﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects
{
    public partial class Product
    {
        public int ProductId {  get; set; }
        public string ProductName {  get; set; }
        public int CategoryId { get; set; }
        public short UnitsInStock { get; set; }
        public decimal? UnitPrice { get; set; }
        public Product() { }
        public Product(int id, string name, int catId, short unitInStock, decimal price)
        {
            this.ProductId = id;
            this.ProductName = name;
            this.CategoryId = catId;
            this.UnitsInStock = unitInStock;
            this.UnitPrice = price;
        }
    }
}
