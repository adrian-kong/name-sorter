using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace name_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "./unsorted-names-list.txt";
            if (args.Length > 0)
            {
                path = args[0];
            }

            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist!");
                return;
            }

            string[] file = File.ReadAllLines(path);
            List<Person> people = File.ReadAllLines(path).Select(line =>
            {
                string[] names = line.Split(' ');
                return new Person(names[names.Length - 1], names.Skip(0).ToArray());
            }).ToList();

            people.Sort();
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }

    class Person : IComparable<Person>
    {
        public Person(string lastName, string[] givenNames)
        {
            LastName = lastName;
            GivenNames = givenNames;
        }

        public string LastName { get; }
        public string[] GivenNames { get; }

        public int CompareTo(Person otherPerson)
        {
            if (LastName.Equals(otherPerson.LastName))
            {
                return string.Join(" ", GivenNames).CompareTo(string.Join(" ", otherPerson.GivenNames));
            }

            return LastName.CompareTo(otherPerson.LastName);
        }

        public override string ToString()
        {
            return $"{string.Join(" ", GivenNames)} {LastName}";
        }
    }
}