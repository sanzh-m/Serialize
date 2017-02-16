using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication14
{
    public class Person
    {
        public string name;
        public int age;

        public Person ()
        {
        }
        public Person (string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return this.name + ", " + this.age + " years old";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Person yessenaly = new Person("Yessenaly", 17);
            //mySerialize(yessenaly);
            //Console.Write(yessenaly);
            myDeserialize();

            Console.ReadKey();
        }

        static void myDeserialize()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            FileStream fs = new FileStream(
                "test.xml", FileMode.Open, FileAccess.Read);
            try
            {
                Person person = xs.Deserialize(fs) as Person;
                Console.WriteLine(person);
            }
            catch (Exception e)
            {
                Console.WriteLine("Deserialize error: " + e);
            }

            fs.Close();
        }

        static void mySerialize(Person person)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            FileStream fs = new FileStream(
                "test.xml", FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                xs.Serialize(fs, person);
            }
            catch (Exception e)
            {
                Console.Write("General error: " + e);
            }
            fs.Close();
        }
    }
}
