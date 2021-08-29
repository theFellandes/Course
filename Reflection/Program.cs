using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Default constructor olmazsa bu notasyon çalışmaz.
            DortIslem dortIslem = new DortIslem {Sayi1 = 12, Sayi2 = 2};
            
            //Reflection
            //Çalışma anında dinamik instance üretir.
            var type = typeof(DortIslem);
            //DortIslem dortIslem = new DortIslem {Sayi1 = 12, Sayi2 = 2};
            //Bu ifadenin aynısı ancak biz bu işlemi çalışma anında yapmış oluyoruz.
            //Gelen tipe göre bu işlemi yapıyoruz.
            //castladık
            var dortIslem2 = (DortIslem)Activator.CreateInstance(type);
            //Constructor parametreli hali
            var dortIslem3 = (DortIslem)Activator.CreateInstance(type, 6, 7);

            var instance = Activator.CreateInstance(type, 6, 7);
            //GetMethod ile methoda ulaşıyoruz, Invoke ile de o methodu çalıştırıyoruz.
            MethodInfo methodInfo = instance.GetType().GetMethod("Topla2");
            Console.WriteLine(instance.GetType()
                .GetMethod("Topla2")
                ?.Invoke(instance, null));
            //method bilgisi toplanıyor, instance ile bağlantıyı kaybettiğimizden hangi örneği
            //çalıştıracağımız bilgisini vermiş oluyoruz.
            Console.WriteLine(methodInfo.Invoke(instance, null));

        }
    }

    class DortIslem
    {
        
        private int _sayi1;
        private int _sayi2;

        
        public DortIslem()
        {
            
        }

        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }

        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }

        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
        
        public int Sayi1
        {
            get => _sayi1;
            set => _sayi1 = value;
        }
        
        public int Sayi2
        {
            get => _sayi2;
            set => _sayi2 = value;
        }
        
        
    }
}