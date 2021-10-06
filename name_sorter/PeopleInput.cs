using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace name_sorter
{
    /**
     * input for generic type to return into a list of itself from given args
     */
    public interface IInput<T>
    {
        List<T> ParseInput(string args);
    }

    /**
     * people input specific type of Person, from given args
     */
    public abstract class PeopleInput : IInput<Person>
    {
        public abstract List<Person> ParseInput(string args);
    }

    /**
     * file input, args is assumed to be path.
     */
    public class PeopleFileInput : PeopleInput
    {
        public override List<Person> ParseInput(string path)
        {
            return File.ReadAllLines(path).Select(fullName => new Person(fullName)).ToList();
        }
    }
}