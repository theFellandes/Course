using System;

namespace Events
{
    public delegate void StockControl();
    public class Product
    {
        private int _stock;

        public Product(int stock)
        {
            //Dependency injection
            _stock = stock;
        }
        public event StockControl StockControlEvent;
        public string ProductName { get; set; }
        //Eğer kişi bu stock konusunda uyarılmak istiyorsa bizim bu set'i geliştirmemiz gerekiyor
        //klasik property tanımı yazacağız
        public int Stock
        {
            get { return _stock;}
            set
            {
                _stock = value;
                //eğer stock 15'ten azsa ve StockControlEvent nesnesine abone olunmuşsa
                //bu abone olunma durumunu da nesne null değilse içinde object vardır yani
                //abone olunmuştur diyerek anlarız
                if (value <= 15 && StockControlEvent != null)
                {
                    //Abone olunmuşsa event'i tetiklemem gerekiyor
                    StockControlEvent();
                }
            }
        }

        public void Sell(int amount)
        {
            Stock -= amount;
            Console.WriteLine("{0} Stock amount: {1}", ProductName, Stock);
        }
        
    }
}