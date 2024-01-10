using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DemoXmlSerializer03
{
    public class Person
    {
        public decimal Salary;
        public Person() { }
        public Person(decimal initialSalary) => Salary= initialSalary;
        public String FirstName { get; set; }    
        public String LastName { get; set; }
        public DateTime DoB    { get; set; }
        public HashSet<Person> Children { get; set;}
    }
}
