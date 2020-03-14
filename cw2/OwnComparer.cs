using System;
using System.Collections.Generic;

namespace Cw2
{
    // Tworzymy własny Comparator implementujący interfejs IEqualityComparer<T>
    // działąjący na obiektach klasy Student
    // Wymogiem jest nadpisanie metod Equals oraz GetHashCode swoją implementacją
    public class OwnComparer : IEqualityComparer<Student>
    {
        
        public bool Equals(Student x, Student y)
        {
            // Do porównania korzystamy z klasy StringComparer
            // W metodzie Equals klasy StringComparer tworzymy wartość tekstową,
            // która będzie porównywana między obiektami
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.FirstName} {x.LastName} {x.Index}",
                    $"{y.FirstName} {y.LastName} {y.Index}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .GetHashCode($"{obj.FirstName} {obj.LastName} {obj.Index}");
        }
    }
}