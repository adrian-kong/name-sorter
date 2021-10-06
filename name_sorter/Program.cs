using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace name_sorter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // default path, take args[0] as input
            string path = "./unsorted-names-list.txt";
            if (args.Length > 0)
            {
                path = args[0];
            }
            
            // main logic.

            IInput<Person> input = new PeopleFileInput();
            List<Person> people = input.ParseInput(path);

            ISorter<Person> sorter = new SortByLastName();
            sorter.Sort(people);

            IOutput<Person> output = new PeopleConsoleOutput();
            output.ParseOutput(people);
        }
    }

    /**
     * objects with properties to compare with.
     */
    public abstract class Nameable
    {
        public string Name { get; set; }
    }

    /**
     * our people object. or individually person!
     */
    public class Person : Nameable
    {
        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}