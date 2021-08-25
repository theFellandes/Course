using DbContext = System.Data.Entity.DbContext;

namespace EntityFrameworkDemo2
{
    public class ETradeContext : DbContext
    {
        public ETradeContext() : base("ETradeContext")
        {
            
        }
        //Tablolarda products arar. Biz context'imizi oluşturduk.
        public System.Data.Entity.DbSet<Product> Products { get; set; }
        
    }
}