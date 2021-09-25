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

            PeopleSorter peopleSorter = new PeopleSorter();
            peopleSorter.ParseInput(path).SortName().WritePeopleToFile();
        }
    }

    /**
     * People Sorter Class to handle all the funny business
     */
    public class PeopleSorter
    {
        // static save directory to sorted output to
        private const string OutputDirectory = "sorted-names-list.txt";

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

        /**
         * Write to console and to directory
         */
        public void WritePeopleToFile()
        {
            foreach (Person person in People)
            {
                Console.WriteLine(person);
            }

            File.WriteAllLines(OutputDirectory, People.Select(person => person.ToString()).ToArray());
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