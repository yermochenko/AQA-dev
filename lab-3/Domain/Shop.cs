using System.Collections.Generic;

namespace lab_3.Domain
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<MobilePhone> Phones { get; set; }

        public override string ToString()
        {
            var result = $"Shop ID #{Id} \"{Name}\"\n{Description}";
            foreach (var mobilePhone in Phones)
            {
                result += $"\n\t{mobilePhone}";
            }
            return result;
        }
    }
}
