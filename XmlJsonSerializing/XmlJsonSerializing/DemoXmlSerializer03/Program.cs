using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using DemoXmlSerializer03;

    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "person.xml";
            var people= new List<Person>();
            people.Add(new Person(20M) { FirstName="Chung", LastName ="Le", DoB = new DateTime(1984,9,25), 
                Children = new HashSet<Person> { new Person(0M) { FirstName="An", LastName="Le", DoB=new DateTime(2012,11,5)} }
            });
            people.Add(new Person(50M) { FirstName = "Thang", LastName = "Nguyen", DoB = new DateTime(1981, 11, 1) });
            people.Add(new Person(8M) { FirstName = "Tam", LastName = "Lo", DoB = new DateTime(1988, 8, 8) });

            var xm= new XmlSerializer(typeof(List<Person>));// luong xmlserial kieu Person
            using FileStream stream= File.Create(filename);
            xm.Serialize(stream, people); //gan luong cho file
            Console.WriteLine(" Write {0} byte to {1}", new FileInfo(filename).Length, filename); 
            stream.Close();
                
            Console.WriteLine(File.ReadAllText(filename));
            Console.ReadLine();

            using FileStream xmlFile = File.Open(filename, FileMode.Open);
            var LoadPepple = (List<Person>)xm.Deserialize(xmlFile);
            foreach(var item in LoadPepple)
            {
                Console.WriteLine($"{item.LastName} has"+ $" { item.Children?.Count??0} children");
                
            }
            xmlFile.Close();
            Console.ReadLine() ;


        }
    }
