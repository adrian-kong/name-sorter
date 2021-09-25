using System;
using System.Collections.Generic;
using System.Linq;
using name_sorter;
using NUnit.Framework;

namespace Tests
{
    public class PersonTests
    {
        [Test]
        public void Test_Parse_Output()
        {
            string input = "given1 given2 given3 given4 last";

            // parse string to person object
            string[] names = input.Split(' ');
            Person person = new Person(names[names.Length - 1], names.Take(names.Length - 1).ToArray());

            // toString is unchanged
            Assert.AreEqual(person.ToString(), input);
        }

        [Test]
        public void Compare_Different_LastName()
        {
            // ["a b parsons", "c d archer"]
            Person person1 = new Person("parsons", new[] {"a", "b"});
            Person person2 = new Person("archer", new[] {"c", "d"});

            // should be sorted to ["c d archer", "a b parsons"], i.e person2 above person1
            // should sort by LastName
            Assert.AreEqual(person1.CompareTo(person2), 1);
            Assert.AreEqual(person2.CompareTo(person1), -1);
        }

        [Test]
        public void Compare_Same_LastName()
        {
            // ["a c parsons", "a b parsons"]
            Person person1 = new Person("parsons", new[] {"a", "c"});
            Person person2 = new Person("parsons", new[] {"a", "b"});

            // should be sorted to ["a b parsons", "a c parsons"], i.e person2 above person1
            // should sort by GivenNames
            Assert.AreEqual(person1.CompareTo(person2), 1);
            Assert.AreEqual(person2.CompareTo(person1), -1);
        }
    }
}