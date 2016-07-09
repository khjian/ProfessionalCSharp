using System;
using System.Collections.Generic;

namespace Demo.LINQ
{
    [Serializable]
    public class Team
    {
        public string Name { get; private set; }
        public IEnumerable<int> Years { get; private set; }

        public Team(string name, params int[] years)
        {
            Name = name;
            Years = new List<int>(years);
        }
    }
}
