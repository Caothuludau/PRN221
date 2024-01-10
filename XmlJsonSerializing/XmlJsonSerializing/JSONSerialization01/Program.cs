using JSONSerialization01;
using System.Text.Json;

class Program

{

    static void Main(string[] ares)
    {
        var emp1 = new Employee(1000M);
        emp1.Name = "Jack";
        emp1.Email = "jack@gmail.com";
        var option = new JsonSerializerOptions { WriteIndented = true };
        Console.WriteLine("****Serialize*****");

        string jsonData = JsonSerializer.Serialize(emp1, option);
        Console.WriteLine(jsonData);
        Console.WriteLine("****Deserialize*****");

        var emp2 = JsonSerializer.Deserialize<Employee>(jsonData);
        Console.WriteLine($"Name:{emp2.Name}, Salary:{emp2.Salary}");
        Console.ReadLine();

    }
}



