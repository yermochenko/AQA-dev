using Bogus;
using System.Collections.Generic;

namespace lab_2_task_4
{
    public class Generator
    {
        public static List<int> GenerateInt()
        {
            Faker faker = new Faker();
            var size = faker.Random.Int(10, 20);
            List<int> list = new List<int>(size);
            for (var i = 0; i < size; i++)
            {
                list.Add(faker.Random.Int(0, 99));
            }
            return list;
        }

        public static List<string> GenerateString()
        {
            Faker faker = new Faker();
            var size = faker.Random.Int(10, 20);
            List<string> list = new List<string>(size);
            for (var i = 0; i < size; i++)
            {
                list.Add(faker.Random.String(5, 10, 'a', 'z'));
            }
            return list;
        }
    }
}
