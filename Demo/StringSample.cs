using System;

namespace Demo
{
    public class StringSample
    {
        public StringSample(string init)
        {
            if(init == null)
                throw new ArgumentNullException("init");
            this.init = init;
        }
        private string init;

        public string GetStringDemo(string first, string second)
        {
            if (first == null)
                throw new ArgumentNullException("first");
            if(string.IsNullOrEmpty(first))
                throw new ArgumentNullException("empty string is not allowed",first);
            if(second == null)
                throw  new ArgumentNullException("second");
            if(second.Length > first.Length)
                throw new ArgumentOutOfRangeException("second","must be shorter than firs");

            int startIndex = first.IndexOf(second);
            if (startIndex < 0)
            {
                return $"{second} not found in {first}";
            }
            else if(startIndex<5)
            {
                return $"removed {second} from {first}:{first.Remove(startIndex, second.Length)}";
            }
            else
            {
                return init.ToUpperInvariant();
            }
        }
    }
}
