using System;

namespace EntityFrameworkDemo2
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}