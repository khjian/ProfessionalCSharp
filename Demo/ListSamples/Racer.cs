using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ListSamples
{
    [Serializable]
    public class Racer:IComparable<Racer>,IFormattable
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Wins { get; set; }

        /// <summary>
        /// 赛车手
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="firstName">FirstName</param>
        /// <param name="lastName">LastName</param>
        /// <param name="country">Country</param>
        /// <param name="wins">Wins</param>
        public Racer(int id, string firstName, string lastName, string country, int wins)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.Wins = wins;
        }

        public Racer(int id, string firstName, string lastName, string country)
            : this(id, firstName, lastName, country, 0)
        { }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null) format = "N";
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
                case "A":
                    return $"{ToString()},{Country} Wins: {Wins}";
                default:
                    throw new FormatException(string.Format(formatProvider,"Format {0} is not supported",format));
            }
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public int CompareTo(Racer other)
        {
            if (other == null) return -1;
            int compare = string.Compare(this.LastName, other.LastName);
            if (compare == 0)
                return string.Compare(this.FirstName, other.FirstName);
            return compare;
        }
    }
}
