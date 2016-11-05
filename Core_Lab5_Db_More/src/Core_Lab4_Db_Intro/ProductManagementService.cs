using Core_Lab5_Db_More.Models;
using Core_Lab5_Db_More.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core_Lab5_Db_More
{
    public class ProductManagementService
    {
        public void ExecuteAll()
        {
            //create the manager
            ProductManagement manager = new ProductManagement();

            // test keys + 2 commands for product add
            //Insert2Products(manager);

            // test keys + 3 commands for customer add
            //Insert3Customers(manager);


            // test numbers
            //DisplayNumberOfProductsAndCustomers(manager);

            // insert 5 categories
            //Insert5Categories(manager);

            // insert 10 products with categories
            //Insert10ProductsWithCategories(manager);

            // lazy loads all categories
            // LazyLoadAllCategories(manager);

            // lazy load all products
            //LazyLoadAllProducts(manager);

            // lazy load categs and products
            //LazyLoadCategoriesAndProducts(manager);

            // eager load categs and products
            //EagerLoadCategoriesAndProducts(manager);

            // explicit load categs and products
            //ExplicitLoadCategoriesAndProducts(manager);

            Console.ReadKey();
        }

        public void Insert2Products(ProductManagement manager)
        {
            ProductRepository prepo = new ProductRepository(manager);

            //test for products
            List<Product> testProducts = new List<Product>()
            {
                new Product() { Name = "Product 1", Description = "The First Product.", StartDate = DateTime.Now.Date, Price = 1000.0, Vat = 11 },//should be valid
                new Product() { Name = "Product 2", Description = "The Second Product.", StartDate = DateTime.Now.Date, Price = 2000.0, Vat = 12 },//should be valid
                new Product() { Name = "Product 3", Description = "The Third Product.", StartDate = DateTime.Now.Date, Price = 3000.0, Vat = 13 },//should be valid
                new Product() { Name = "Product 4 With a Length Bigger than 50 Characters 50 51.", Description = "The 2ND Product.", StartDate = DateTime.Now.Date, Price = 1000, Vat = 12 },//should not be valid
                new Product() { Name = "Product 5 With No Price", Description = "The First Product.", StartDate = DateTime.Now.Date, Vat = 12 }//should be valid
                
            };

            Action insertValid = new Action(() => prepo.Create(testProducts[0]));
            Action insertValid2 = new Action(() => prepo.Create(testProducts[1]));
            Action insertInValid1 = new Action(() => prepo.Create(testProducts[3]));
            TestOperation(insertValid);
            TestOperation(insertValid2);
            //TestOperation(insertInValid1); //invalid
        }

        public void Insert3Customers(ProductManagement manager)
        {
            CustomerRepository crepo = new CustomerRepository(manager);

            //test for customers
            List<Customer> testCustomers = new List<Customer>()
            {
                new Customer() { Name = "John 2", Address = "Anywhere", Email = "marian.focsa@outlook.com", PhoneNumber = "0749936026" },
                new Customer() { Name = "John 3", Address = "Anywhere", Email = "marian.focsa3@outlook.com", PhoneNumber = "0749936024" },
                new Customer() { Name = "John 4", Address = "Anywhere", Email = "marian.focsa2@outlook.com", PhoneNumber = "0749936025" },
                new Customer() { Address = "Everywhere", Email = "xxx", PhoneNumber = "xxx" },
            };

            Action cinsertValid = new Action(() => crepo.Create(testCustomers[0]));
            Action cinsertValid2 = new Action(() => crepo.Create(testCustomers[1]));
            Action cinsertValid3 = new Action(() => crepo.Create(testCustomers[2]));
            Action cinsertInValid1 = new Action(() => crepo.Create(testCustomers[3]));
            TestOperation(cinsertValid);
            TestOperation(cinsertValid2);
            TestOperation(cinsertValid3);
            //TestOperation(cinsertInValid1); //invalid
        }

        public void Insert5Categories(ProductManagement manager)
        {
            CategoryRepository carepo = new CategoryRepository(manager);

            List<Category> testCategories = new List<Category>()
            {
                new Category() { Name = "Category 1", Description = "Description 1" },
                new Category() { Name = "Category 2", Description = "Description 2" },
                new Category() { Name = "Category 3", Description = "Description 3" },
                new Category() { Name = "Category 4", Description = "Description 4" },
                new Category() { Name = "Category 5", Description = "Description 5" }

            };

            Action insert1 = new Action(() => carepo.Create(testCategories[0]));
            Action insert2 = new Action(() => carepo.Create(testCategories[1]));
            Action insert3 = new Action(() => carepo.Create(testCategories[2]));
            Action insert4 = new Action(() => carepo.Create(testCategories[3]));
            Action insert5 = new Action(() => carepo.Create(testCategories[4]));

            TestOperation(insert1);
            TestOperation(insert2);
            TestOperation(insert3);
            TestOperation(insert4);
            TestOperation(insert5);
        }

        public void Insert10ProductsWithCategories(ProductManagement manager)
        {
            ProductRepository prepo = new ProductRepository(manager);

            //test for products
            List<Product> testProducts = new List<Product>()
            {
                new Product() { Name = "Product 1", Description = "Product Nr. 1.", StartDate = DateTime.Now, Price = 1000.0, Vat = 1,
                    CategoryId = new Guid("563deffa-c1c9-4d11-f590-08d4058d7355") },
                new Product() { Name = "Product 2", Description = "Product Nr. 2.", StartDate = DateTime.Now, Price = 1000.0, Vat = 1,
                    CategoryId = new Guid("563deffa-c1c9-4d11-f590-08d4058d7355") },
                new Product() { Name = "Product 3", Description = "Product Nr. 3.", StartDate = DateTime.Now, Price = 1000.0, Vat = 1,
                    CategoryId = new Guid("563deffa-c1c9-4d11-f590-08d4058d7355") },
                new Product() { Name = "Product 4", Description = "Product Nr. 4.", StartDate = DateTime.Now, Price = 1000.0, Vat = 1,
                    CategoryId = new Guid("0953c081-cde5-4a04-f591-08d4058d7355") },
                new Product() { Name = "Product 5", Description = "Product Nr. 5.", StartDate = DateTime.Now, Price = 1000.0, Vat = 1,
                    CategoryId = new Guid("0953c081-cde5-4a04-f591-08d4058d7355") },
                new Product() { Name = "Product 6", Description = "Product Nr. 6.", StartDate = DateTime.Now, Price = 1000.0, Vat = 1,
                    CategoryId = new Guid("325326c7-4660-4fed-f592-08d4058d7355") },
                new Product() { Name = "Product 7", Description = "Product Nr. 7.", StartDate = DateTime.Now, Price = 1000.0, Vat = 1,
                    CategoryId = new Guid("325326c7-4660-4fed-f592-08d4058d7355") },
                new Product() { Name = "Product 8", Description = "Product Nr. 8.", StartDate = DateTime.Now, Price = 1000.0, Vat = 1,
                    CategoryId = new Guid("325326c7-4660-4fed-f592-08d4058d7355") },
                new Product() { Name = "Product 9", Description = "Product Nr. 9.", StartDate = DateTime.Now, Price = 1000.0, Vat = 1,
                    CategoryId = new Guid("3cae9689-b4ac-43ea-f593-08d4058d7355") },
                new Product() { Name = "Product 10", Description = "Product Nr. 10.", StartDate = DateTime.Now, Price = 1000.0, Vat = 1,
                    CategoryId = new Guid("3cae9689-b4ac-43ea-f593-08d4058d7355") },


            };

            Action insert1 = new Action(() => prepo.Create(testProducts[0]));
            Action insert2 = new Action(() => prepo.Create(testProducts[1]));
            Action insert3 = new Action(() => prepo.Create(testProducts[2]));
            Action insert4 = new Action(() => prepo.Create(testProducts[3]));
            Action insert5 = new Action(() => prepo.Create(testProducts[4]));
            Action insert6 = new Action(() => prepo.Create(testProducts[5]));
            Action insert7 = new Action(() => prepo.Create(testProducts[6]));
            Action insert8 = new Action(() => prepo.Create(testProducts[7]));
            Action insert9 = new Action(() => prepo.Create(testProducts[8]));
            Action insert10 = new Action(() => prepo.Create(testProducts[9]));

            TestOperation(insert1);
            TestOperation(insert2);
            TestOperation(insert3);
            TestOperation(insert4);
            TestOperation(insert5);
            TestOperation(insert6);
            TestOperation(insert7);
            TestOperation(insert8);
            TestOperation(insert9);
            TestOperation(insert10);
        }

        public void LazyLoadAllCategories(ProductManagement manager)
        {
            foreach (Category category in manager.Categories)
            {
                Console.WriteLine("{0} {1}", category.Name, category.Description);
            }
        }

        public void LazyLoadAllProducts(ProductManagement manager)
        {
            foreach (Product product in manager.Products)
            {
                Console.WriteLine("{0} {1}", product.Name, product.Description);
            }
        }

        public void LazyLoadCategoriesAndProducts(ProductManagement manager)
        {
            var query = manager.Categories.ToList();
            foreach (Category category in query)
            {
                // lazy loading not working in EF7
                int count = category.Products == null? 0 : category.Products.Count;
                Console.WriteLine("{0} has {1} number of products assigned.", category.Name, count);
            }
        }

        public void EagerLoadCategoriesAndProducts(ProductManagement manager)
        {
            var query = manager.Categories.Include("Products");
            foreach (Category category in query)
            {
                Console.WriteLine("{0} has {1} number of products assigned.", category.Name, category.Products.Count);
            }
        }

        public void ExplicitLoadCategoriesAndProducts(ProductManagement manager)
        {
            var query = manager.Categories.ToList();
            foreach (Category category in query)
            {
                var products = manager.Entry(category).Collection(x => x.Products);
                if (!products.IsLoaded)
                    products.Load();
                Console.WriteLine("{0} has {1} number of products assigned.", category.Name, category.Products.Count);
            }
        }

        public void DisplayNumberOfProductsAndCustomers(ProductManagement manager)
        {
            Action nrOfProducts = new Action(() =>
            {
                Console.WriteLine("Number of products: {0}.", manager.Products.Count());
            });
            Action nrOfCustomers = new Action(() =>
            {
                Console.WriteLine("Number of customers: {0}.", manager.Customers.Count());
            });

            TestOperation(nrOfProducts);
            TestOperation(nrOfCustomers);
        }

        /// <summary>
        /// Helper to try-catch executions.
        /// </summary>
        /// <param name="action">The method to execute.</param>
        private void TestOperation(Action action)
        {
            try
            {
                action();
                Console.WriteLine("Success.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                    Console.WriteLine(">>" + e.InnerException.Message);

            }
            finally
            {
                Console.WriteLine();
            }
        }
    }
}
