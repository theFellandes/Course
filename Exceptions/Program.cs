using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Runtime.ExceptionServices;

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
            //Parametre türü olarak method yollayacağız.
            // () => {} delegate demek, () methoda karşılık geliyor
            // HandleException(() =>
            // {
            //     Found();
            // });
            //kullanım yöntemlerinden bir diğeri de bu
            HandleException(Found);
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