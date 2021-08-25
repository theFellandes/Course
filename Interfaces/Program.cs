namespace Interfaces
{
    public class Program
    {
        static void main(string[] args)
        {
            
            //Bir veriyi hem SQL database'e hem de Oracle'a yazmak istiyoruz
            ICustomerDal[] customerDals = new ICustomerDal[2]
            {
                new SqlServerCustomerDal(),
                new OracleCustomerDal()
            };

            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }

        }

        private static void PolymorphismExample()
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new OracleCustomerDal());
        }
    }
}