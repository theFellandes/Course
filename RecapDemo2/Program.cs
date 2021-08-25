using System;

namespace RecapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //Yeni instance'ını oluşturduk
            customerManager.Logger = new DatabaseLogger();
            //Yeni bir loglama ihtiyacı duyarsak sadece new FileLogger tarzı değiştirme yaparız.
            customerManager.Add();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        //Interface'in nimetlerinden yararlandık
        //property injection, normalde bu constructor ile yapılır.
        public ILogger Logger { get; set; }
        public void Add()
        {
            Logger.Log();
            Console.WriteLine("Customer Added!!");
        }
    }
    
    //Burada interface seçilmesinin sebebi DatabaseLogger ile FileLogger ve SmsLogger
    // tümüyle farklı kodlanır. Kullanan herkes ayrı ayrı implementasyon yapılırdı.
    //  FileLogger ve DatabaseLogger eğer aynı olup sadece SmsLogger farklı olsaydı o zaman
    //   virtual ya da abstract class kullanırdık.
    
    interface ILogger
    {
        void Log();
    }
    

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file!");
        }
    }
}