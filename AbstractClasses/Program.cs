﻿using System;
using System.Net.Sockets;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Oracle();
            database.Add();
            database.Delete();

            Database database2 = new SqlServer();
            database2.Add();
            database2.Delete();
        }
    }

    abstract class Database
    {
        //Senaryomuzda her yerde aynı bir ekleme işlemimiz var
        //Tamamlanmış method
        public void Add()
        {
            Console.WriteLine("Added by default");
        }

        //Değişiklik gösteren bir Delete işlemimiz var
        //Tamamlanmamış Class
        public abstract void Delete();
    }

    class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted from Sql");
        }
    }

    class Oracle : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted By Oracle");
        }
    }
}