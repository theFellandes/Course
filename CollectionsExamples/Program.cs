using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tip güvenliksiz ArrayList
            ArrayList cities = new ArrayList();
            cities.Add("Ankara");
            cities.Add(1);

            foreach (var element in cities)
            {
                Console.WriteLine(element);
            }

            //Tip güvenlikli List
            List<Test> testList = new List<Test>();
            testList.Add(new Test("sdfa", 12));

            List<Test> testList2 = new List<Test>
            {
                new Test("ffff", 33),
                new Test("aaaa", 22)
            };
            
            //Array şeklinde ekleme yapmak
            testList2.AddRange(new Test[2]
            {
                new Test("dsfa", 23),
                new Test("ewqr", 213)
            });

            //Predicate
            testList2.RemoveAll(t => t.Name == "sdfa");
            testList2.RemoveAll(testElement => testElement.Name.Equals("ffff", 
                StringComparison.OrdinalIgnoreCase));

            //Key-Value
            Dictionary<Test, string> testDictionary = new Dictionary<Test, string>();
            Test test = new Test("fdsaf", 13);
            testDictionary.Add(test, "ffaa");
            Console.WriteLine(testDictionary[test]);
            bool doesDictionaryContainsKey = testDictionary.ContainsKey(test);
            bool doesDictionaryContainsValue = testDictionary.ContainsValue("ffaa");
            
            Console.WriteLine(doesDictionaryContainsKey);
            Console.WriteLine(doesDictionaryContainsValue);

            foreach (var item in testDictionary)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Key.Name);
                Console.WriteLine(item.Key.Id);
                Console.WriteLine(item.Value);
            }

        }
    }

    class Test
    {
        private string _name;
        private int _id;
        public Test(string name, int id)
        {
            _id = id;
            _name = name;
        }

        public void PrintSomething()
        {
            Console.WriteLine("Print Something");
        }

        public int Id
        { 
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}