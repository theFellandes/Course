using System;

namespace Delegates
{
    //Elçilik
    public delegate void MyDelegate();

    public delegate void MyDelegate2(string text);

    public delegate int MyDelegate3(int num1, int num2);
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.SendMessage();
            customerManager.ShowAlert();

            //Bu örnek void olan ve herhangi bir parametresi olmayan methodlara
            //elçilik yapmakta kullanılan operasyon
            
            //Elçi
            //herhangi bir parametre bir şey verilmiyor.
            //bu yukarıdaki formatta çalışan bir elçi
            //birden fazla elçi oluşturulabilir.
            //delegate henüz bu işlemi gerçekleştirmedi sadece söyledik
            MyDelegate myDelegate = customerManager.SendMessage;
            
            //delegate'e yeni işlem tanımlamak için o işlemi += ile ekleriz
            myDelegate += customerManager.ShowAlert;

            //burada da delegate'ten SendMessage işlemini çıkarttık
            myDelegate -= customerManager.SendMessage;
            
            //Burada da delegate'imize işi yaptırdık
            myDelegate();
            
            //Delegate'ler yapılacak işlemleri arka arkaya toplamayı sağlar
            //Bu şu anda en eski delegate işlemlerinden

            // burada formatına yani parametre olarak string alan bir şey olmadığı
            // için alttaki kod hata verir. Method overload yapılırsa hata gider.
            // MyDelegate2 myDelegate2 = customerManager.SendMessage;
            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;
            myDelegate2("hi");

            //Return döndüren bir delegate varsa en son çalıştırılan işlem
            //sonuç olarak yazılır. Mesela burada sonuc 6 olarak printlenir
            //çünkü son işlem olarak myDelegate3 2 * 3 işlemini döndürür.
            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;
            myDelegate3 += matematik.Carp;
            var sonuc = myDelegate3(2, 3);

            
            Console.WriteLine(sonuc);
        }
    }

    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello!");
        }
        public void SendMessage2(string message)
        {
            Console.WriteLine("Hello! {0}", message);
        }

        public void ShowAlert()
        {
            Console.WriteLine("Be careful!");
        }
        
        public void ShowAlert2(string message)
        {
            Console.WriteLine("Be careful! {0}", message);
        }
    }

    public class Matematik
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}