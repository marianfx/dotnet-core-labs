using Business;
using BussinessManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ManagerProdTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        public ProductRepository CreateSUT()
        {
            return new ProductRepository(new List<Business.Product>()
            {
                new Product("1", "1", DateTime.Now, 1, 1),
                new Product("2", "2", DateTime.Now, 2, 2),
                new Product("3", "2", DateTime.Now, 3, 3),
            });
        }

        [TestMethod]
        public void When_PRIsInstanciated_Then_ShouldReturnProduct3()
        {
            ProductRepository pr = CreateSUT();

            Product result = pr.GetProductByName("3");
            Assert.AreEqual(result, pr.Products[2]);
        }
        
        [TestMethod]
        public void When_PRIsInstanciated_Then_ShouldReturnALlProducts()
        {
            ProductRepository pr = CreateSUT();

            var result = pr.FindAllProducts();
            Assert.AreEqual(result, pr.Products);
        }


        [TestMethod]
        public void When_PRIsInstanciated_Then_ShouldAddOneProduct()
        {
            ProductRepository pr = CreateSUT();

            pr.AddProduct(new Product("4", "4", DateTime.Now, 4, 4);
            Assert.AreEqual(pr.Products.Count, 4);
        }


        [TestMethod]
        public void When_PRIsInstanciated_Then_ShouldReturnProductPosition2()
        {
            ProductRepository pr = CreateSUT();

            Product result = pr.GetProductByPosition(2);
            Assert.AreEqual(result, pr.Products[2]);
        }
        
        [TestMethod]
        public void When_PRIsInstanciated_Then_ShouldRemoveOneProduct()
        {
            ProductRepository pr = CreateSUT();

            pr.RemoveProductByName("3");
            Assert.AreEqual(pr.Products.Count, 2);
        }
        
        [TestMethod]
        public void When_PRIsInstanciated_Then_ShouldThrowException()
        {
            ProductRepository pr = CreateSUT();

            Action action = () => pr.GetProductByPosition(-2);

            Assert.ThrowsException<ArgumentException>(action);
        }

    }
}
