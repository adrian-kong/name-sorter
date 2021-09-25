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

            PeopleSorter peopleSorter = new PeopleSorter().ParseInput(path).SortName();

            List<Person> people = peopleSorter.People;
            people.ForEach(Console.WriteLine);

            const string outputDirectory = "sorted-names-list.txt";
            File.WriteAllLines(outputDirectory, people.Select(person => person.ToString()).ToArray());
        }
    }

    /**
     * People Sorter Class to handle all the funny business
     */
    public class PeopleSorter
    {
        public List<Person> People { get; set; }

        /**
         * Assumes input path exists or will crash
         * Reads lines in input file and populates People list
         */
        public PeopleSorter ParseInput(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File {path} does not exist!");
            }

            People = File.ReadAllLines(path).Select(line =>
            {
                string[] names = line.Split(' ');
                // Person(n-th word, 1...n-1 words)
                return new Person(names[names.Length - 1], names.Take(names.Length - 1).ToArray());
            }).ToList();

            return this;
        }

        /**
         * Sort the people list by names
         */
        public PeopleSorter SortName()
        {
            People.Sort();
            return this;
        }
    }

    /**
     * Comparable Person object, to handle all the comparing persons logic
     */
    public class Person : IComparable<Person>
    {
        private string LastName { get; }

        private string[] GivenNames { get; }

        public Person(string lastName, string[] givenNames)
        {
            LastName = lastName;
            GivenNames = givenNames;
        }

        /**
         * Compares based on LastName else GivenNames
         */
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