using System;
using System.Collections.Generic;
using System.Linq;
using name_sorter;
using NUnit.Framework;

namespace Tests
{
    public class PersonTests
    {
        // TODO: do input, output tests.

        [Test]
        public void Test_SortByLastName()
        {
            // ["a c parsons", "a b parsons"]
            ISorter<Person> sorter = new SortByLastName();
            List<Person> people = new List<Person>();

            Person person1 = new Person("a c parsons");
            Person person2 = new Person("a b parsons");
            people.Add(person1);
            people.Add(person2);

            sorter.Sort(people);

            // should be sorted to ["a b parsons", "a c parsons"], i.e person2 above person1
            // should sort by GivenNames
            Assert.AreEqual(people.ElementAt(0).ToString(), "a b parsons");
            Assert.AreEqual(people.ElementAt(1).ToString(), "a c parsons");
        }
    }
}