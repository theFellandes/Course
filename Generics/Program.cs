using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            List<string> cities = utilities.BuildList<string>("Ankara", "İstanbul", "İzmir");
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

            List<Customer> result = utilities.BuildList(new Customer{FirstName = "Foo"}, 
                new Customer{FirstName = "Foo2"});
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new (items);
        }
    }
    
    //T type'tan gelir
    //Bu customer için de ve product için de geçerli
    // interface IRepository<T>
    // {
    //     List<T> GetAll();
    //     T Get(int id);
    //     void Add(T entity);
    //     void Delete(T entity);
    //     void Update(T entity);
    // }
    
    //Generic constraint
    //where T : class denen şey class değil, reference tipi olması gerekiyor.
    //class olmasını sağlamanın yolu class ve new() yapmamız gerekiyor yani new'lenebilir bir
    //reference tipi olmasını şartlıyoruz.
    //T reference tipi olmalı, IEntity'den implement edilmeli ve new'lenmeli
    //new() her zaman sonda olmak zorunda
    //Eğer struct deseydik değer tiplere karşılık gelirdi.
    interface IRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    interface IEntity
    {
        
    }

    // interface IProductDal
    // {
    //     List<Product> GetAll();
    //     Product Get(int id);
    //     void Add(Product product);
    //     void Delete(Product product);
    //     void Update(Product product);
    // }
    
    interface IProductDal : IRepository<Product>
    {
        
    }

    class Product : IEntity
    {
        
    }

    class ProductDal : IProductDal
    {
        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
    
    // interface ICustomerDal
    // {
    //     List<Customer> GetAll();
    //     Customer Get(int id);
    //     void Add(Customer customer);
    //     void Delete(Customer customer);
    //     void Update(Customer customer);
    // }
    
    interface ICustomerDal : IRepository<Customer>
    {
        void Custom();
    }

    class Customer : IEntity
    {
        public string FirstName { get; set; }
    }

    class CustomerDal : ICustomerDal
    {
        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Custom()
        {
            throw new NotImplementedException();
        }
    }

    
}