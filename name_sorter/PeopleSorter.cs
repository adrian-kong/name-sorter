using System.Collections.Generic;

namespace name_sorter
{
    /**
     * interface to sort generic classes
     */
    public interface ISorter<T>
    {
        void Sort(List<T> people);
    }

    /**
     * people sorter interface, perhaps we might want to have some distinction in data types
     */
    public abstract class PeopleSorter : ISorter<Person>
    {
        public abstract void Sort(List<Person> people);
    }

    /**
     * specific sorter to sort people by last name
     */
    public class SortByLastName : PeopleSorter
    {
        public override void Sort(List<Person> people)
        {
            people.Sort(Comparer<Person>.Create((p1, p2) =>
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
}