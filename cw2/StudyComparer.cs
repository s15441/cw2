using System;
using System.Collections.Generic;

namespace Cw2
{
    public class StudyComparer : IEqualityComparer<Study>
    {
        public bool Equals(Study x, Study y)
        {
            return StringComparer.InvariantCultureIgnoreCase
                .Equals($"{x.Department} {x.Mode}, {y.Department} {y.Mode}");
        }

        public int GetHashCode(Study obj)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .GetHashCode($"{obj.Department} {obj.Mode}");
        }
    }
}