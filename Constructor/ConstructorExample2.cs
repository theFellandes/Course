namespace Constructor
{
    internal class Product2
    {
        public Product2()
        {
            
        }
        
        public Product2(int id, string name)
        {
            //isimleri fonksiyonlarla aynı get set ederken
            Id = id;
            Name = name;
        }
        

        public Product2(int id, string name, int foo) : this(id, name)
        {
            Foo = foo;
        }

        private int Id { get; set; }

        private string Name { get; set; }

        private int Foo { get; set; }
    }
}