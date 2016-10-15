using Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BussinessManager
{
    public class ProductRepository
    {
        public List<Product> Products { get; }

        public ProductRepository(List<Product> products)
        {
            Products = products;
        }


        public Product GetProductByName(string name)
        {
            foreach (Product p in Products)
            {
                if (p.Name == name)
                    return p;
            }

            return null;
        }

        public List<Product> FindAllProducts()
        {
            return Products;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public Product GetProductByPosition(int positon)
        {
            if (positon < 0 || positon >= Products.Count)
                throw new ArgumentException("Position should pe greater than 0 and less than Length.");

            return Products.ElementAt(positon);
        }

        public void RemoveProductByName(string name)
        {
            for (int i = 0; i < Products.Count; i++)
                if (Products[i].Name == name)
                {
                    Products.Remove(Products[i]);
                    break;
                }
        }
    }
}
