using DemoXmlSerializer02;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "people.xml";
        // Create an object graph
        var people = new List<Person> {
            new Person(30000M) { FirstName = "Alice",
                LastName = "Smith", DateOfBirth = new DateTime(1972, 3, 16) },
            new Person(20000M) { FirstName = "Chung", LastName = "Le",
                DateOfBirth = new DateTime(1984, 09, 25),
                Children = new HashSet<Person>
                { new Person(0M) { FirstName = "An", LastName = "le",
                    DateOfBirth = new DateTime(2012, 11, 5) }
                }
            }

        };
        // Create object that will format a List of Persons as XML
        var xs = new XmlSerializer(typeof(List<Person>));
        // create a file to write to
        using FileStream stream = File.Create(fileName);
        // serialize the object graph to the stream
        xs.Serialize(stream, people);
        Console.WriteLine("Written {0} bytes of XML to {1}",
        new FileInfo(fileName).Length, fileName);
        stream.Close();
        // Display the serialized object graph
        Console.WriteLine(File.ReadAllText(fileName));
        Console.WriteLine(new string('*', 30));
        // Deserializing with XML
        using FileStream xmlLoad = File.Open(fileName, FileMode.Open);
        // Deserialize and cast the object graph into a List of Person
        var loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);
        foreach (var item in loadedPeople)
        {
            Console.WriteLine($"{item.LastName} has " +
            $"{item.Children.Count} children.");

        }
        xmlLoad.Close();
        Console.ReadLine();
    }//end Main
}//end Program