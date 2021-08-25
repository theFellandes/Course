using System;
using System.ComponentModel.DataAnnotations;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer {Id = 1, LastName = "Engin", Age = 32};
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
        }
    }

    //Classa attribute ekledik
    [ToTable("Customers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    class CustomerDal
    {
        //Bu attribute eski method demek
        //Kullanıcıyı bilgilendirecek mesaj da yazdık.
        [Obsolete("Don't use Add, instead use AddNew method")]
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!",customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }

    //Attribute'ların sonunda Attribute olması ve Attribute'tan inherit edilmesi gerekiyor
    //Required Attribute'a da attribute ekleyebiliyoruz.
    //AttributeTargets.All bu attribute'u herkese kullanabilirsin demek.
    //AttributeTargets.Class denseydi yalnızca class'lara eklenebilir olacaktı.
    //AttributeTargets.Property diyerek sadece nesneler için kullanabiliriz.
    //Pipe'layarak | işareti ile, birden fazla target seçebiliyoruz.
    //AttributeTargets.Class | AttributeTargets.Property gibi
    //AttributeTargets.Property, AllowMultiple = true şu anlama geliyor, Attribute'un üstüne attribute koymayı sağlıyor.
    [AttributeUsage(AttributeTargets.All)]
    class RequiredPropertyAttribute : Attribute
    {
        
    }

    //Attribute'a parametre yollayabilmek için böyle yapmamız gerekli
    [AttributeUsage(AttributeTargets.Class)]
    class ToTableAttribute : Attribute
    {
        private string _tableName;

        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }

    }
}