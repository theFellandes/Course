using System;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();
            sqlServer.Add();
            MySql mySql = new MySql();
            mySql.Add();
        }
    }

    internal class Database
    {
        public virtual void Add()
        {
            Console.WriteLine("Added by default");
        }

        public virtual void Delete()
        {
            Console.WriteLine("Deleted by default");
        }
    }

    internal class SqlServer : Database
    {
        //Override
        public override void Add()
        {
            Console.WriteLine("Added with SQLServer");
            //Runs default method
            base.Add();
        }
    }

    internal class MySql : Database
    {
        
    }
}