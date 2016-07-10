using System;
using System.Collections.Generic;

namespace Demo.LINQ
{
    [Serializable]
    public class Racer:IComparable<Racer>,IFormattable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Wins { get; set; }
        public string Country { get; set; }
        public int Starts { get; set; }
        public IEnumerable<string> Cars { get; set; }
        public IEnumerable<int> Years { get; set; }

        public Racer(string firstName, string lastName, string country, int starts, int wins, IEnumerable<int> years,
            IEnumerable<string> cars)
        {
            FirstName = firstName;
            LastName = lastName;
            Wins = wins;
            Country = country;
            Starts = starts;

            Years = new List<int>(years);
            Cars = new List<string>(cars);
        }

        public Racer(string firstName, string lastName, string country, int starts, int wins)
            : this(firstName, lastName, country, starts, wins, null, null)
        {
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public int CompareTo(Racer other)
        {
            if (other == null) return -1;
            return string.Compare(this.LastName, other.LastName);
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if(format==null)
                return ToString();
            switch (format.ToUpper())
            {
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "W":
                    return $"{ToString()},Wins:{Wins}";
                case "C":
                    return $"{ToString()},Country:{Country}";
                case "S":
                    return Starts.ToString();
                case "A":
                    return $"{ToString()},{Country};starts:{Starts}, Wins: {Wins}";
                default:
                    throw new FormatException(string.Format(formatProvider, "Format {0} is not supported", format));
            }
        }
    }
}
