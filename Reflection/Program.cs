using System;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Default constructor olmazsa bu notasyon çalışmaz.
            DortIslem dortIslem = new DortIslem {Sayi1 = 12, Sayi2 = 2};
            
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