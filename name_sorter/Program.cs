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

            IPeopleInput input = new PeopleFileInput();
            List<Person> people = input.parseInput(path);

            IPersonSorter sorter = new SortByLastName();
            sorter.sort(people);

            IPeopleOutput output = new PeopleConsoleOutput();
            output.parseOutput(people);
        }
    }

    public interface IPersonSorter
    {
        void sort(List<Person> persons);
    }

    public class SortByLastName : IPersonSorter
    {
        public void sort(List<Person> persons)
        {
            persons.Sort(Comparer<Person>.Create((p1, p2) =>
            {
                string[] p1_names = p1.Name.Split(' ');
                string[] p2_names = p2.Name.Split(' ');

                string p1_lastname = p1_names[p1_names.Length - 1];
                string p2_lastname = p2_names[p2_names.Length - 1];

                if (p1_lastname == p2_lastname)
                {
                    return p1.Name.CompareTo(p2.Name);
                }

                return p1_names[p1_names.Length - 1].CompareTo(p2_names[p2_names.Length - 1]);
            }));
        }
    }

    interface IPeopleInput
    {
        List<Person> parseInput(string path);
    }

    public class PeopleFileInput : IPeopleInput
    {
        public List<Person> parseInput(string path)
        {
            return File.ReadAllLines(path).Select(fullName => new Person(fullName)).ToList();
        }
    }

    interface IPeopleOutput
    {
        void parseOutput(List<Person> people);
    }

    public class PeopleConsoleOutput : IPeopleOutput
    {
        public void parseOutput(List<Person> people)
        {
            people.ForEach(Console.WriteLine);
        }
    }

    public class PeopleFileOutput : IPeopleOutput
    {
        private string directory { get; set; }

        public void parseOutput(List<Person> people)
        {
            File.WriteAllLines(directory, people.Select(person => person.ToString()).ToArray());
        }
    }


    public interface INameable
    {
        string Name { get; set; }
    }

    /**
     * Comparable Person object, to handle all the comparing persons logic
     */
    public class Person : INameable
    {
        public string Name { get; set; }

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