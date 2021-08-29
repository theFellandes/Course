using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            // try
            // {
            //     Found();
            // }
            // catch (RecordNotFoundException exception)
            // {
            //     Console.WriteLine(exception.Message);
            // }
            // finally
            // {
            //     Console.WriteLine("Does something");
            // }
            //////////////////////////////////
            //Parametre türü olarak method yollayacağız.
            // () => {} delegate demek, () methoda karşılık geliyor
            // HandleException(() =>
            // {
            //     Found();
            // });
            //kullanım yöntemlerinden bir diğeri de bu
            //HandleException(Found);
            /////////////////////////////////////
            // Func kullanımı, en sonda yazılan dönüş tipi, ilk 2 kısım fonksiyon parametreleri
            Func<int, int, int> add = Topla;
            
            //Methodu çalıştırmasını söyledik delegate'e ve parametrelerini yolladık
            Console.WriteLine(add(3, 5));
            
            //Bu şekilde sadece parametresiz methoda delegate yapıyor dönüş tipi int
            //random sayı üreten kod bloğu
            Func<int> getRandomNumber = delegate()
            {
                Random random = new Random();
                return random.Next(1, 100);
            };
            Console.WriteLine(getRandomNumber());

            //Bu thread sleep'i koymazsak 2 randomNumberGenerator aynı değeri üretir.
            Thread.Sleep(2000);
            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);
            Console.WriteLine(getRandomNumber2);
        }

        static int Topla(int x, int y)
        {
            return x + y;
        }

        //Action {} arasına tekabül ediyor
        //Bunu merkezi bir class içine koyarız oradan çağırırız.
        //Action delegation'ı
        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void Found()
        {
            List<string> students = new List<string> {"A", "B", "GFDS"};

            if (!students.Contains("Ahmet"))
            {
                throw new RecordNotFoundException("Record not found.");
            }

            Console.WriteLine("Record Found!");
        }
    }
}