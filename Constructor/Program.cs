using System;

namespace Constructor
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var product = new Product {Id = 12, Name = "asdf"};
            var product2 = new Product(10, "aaaa");
            var product3 = new Product(15, "ffff", 3);
            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger());
            employeeManager.Add();
            Console.WriteLine("Id = {0}; Name = {1}; Foo = {2}",product3.Id, product3.Name, product3.Foo);

            PersonManager personManager = new PersonManager("Product");
            personManager.Add();
            Console.ReadLine();
        }
    }

    internal class Product
    {
        private int _id;
        private string _name;
        private int _foo;

        public Product()
        {
            
        }
        
        public Product(int id, string name)
        {
            _id = id;
            _name = name;
        }
        

        public Product(int id, string name, int foo) : this(id, name)
        {
            _foo = foo;
        }
        
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Foo
        {
            get => _foo;
            set => _foo = value;
        }
    }

    interface ILogger
    {
        void Log();
    }

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
           Console.WriteLine("Database Logged"); 
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("File Logged");
        }
    }

    class EmployeeManager
    {
        private ILogger _logger;
        
        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added");
        }
    }

    //BaseClass tüm sınıflarda olacak işlemleri barındıracak
    class BaseClass
    {

        private string _entity;

        public BaseClass(string entity)
        {
            _entity = entity;
        }
        
        public void Message()
        {
            Console.WriteLine("{0} message", _entity);
        }
        
    }

    class PersonManager : BaseClass
    {
        public PersonManager(string entity) : base(entity)
        {
            
        }

        public void Add()
        {
            Console.WriteLine("Added!");
            Message();
        }

    }
}