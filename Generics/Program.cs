using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    
    //T type'tan gelir
    //Bu customer için de ve product için de geçerli
    interface IRepository<T>
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
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

    class Product
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

    }

    class Customer
    {
        
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
    }

    
}