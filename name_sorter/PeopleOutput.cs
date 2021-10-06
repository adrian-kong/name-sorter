using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace name_sorter
{
    /**
     * output interface, generic class type allowing wide range of outputs
     */
    public interface IOutput<T>
    {
        void ParseOutput(List<T> people);
    }

    /**
     * people output specifically for person type in case we want to do something funky
     */
    public abstract class PeopleOutput : IOutput<Person>
    {
        public abstract void ParseOutput(List<Person> people);
    }

    /**
     * console implementation of output
     */
    public class PeopleConsoleOutput : PeopleOutput
    {
        public override void ParseOutput(List<Person> people)
        {
            people.ForEach(Console.WriteLine);
        }
    }

    /**
     * file implementation of output
     */
    public class PeopleFileOutput : PeopleOutput
    {
        private string directory { get; set; }

        public PeopleFileOutput(string directory)
        {
            this.directory = directory;
        }

        public override void ParseOutput(List<Person> people)
        {
            File.WriteAllLines(directory, people.Select(person => person.ToString()).ToArray());
        }
    }
}