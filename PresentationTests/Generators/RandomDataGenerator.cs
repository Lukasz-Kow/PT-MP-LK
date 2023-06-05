using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.Generators
{
    public class RandomDataGenerator
    {
        public string GenerateRandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var result = new string(
                Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            return result;
        }

        public int GenerateRandomInt(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        public DateTime GenerateRandomDate()
        {
            var random = new Random();
            var start = new DateTime(1995, 1, 1);
            var range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        public bool GenerateRandomBool()
        {
            var random = new Random();
            return random.Next(0, 2) > 0;
        }
    }
}
