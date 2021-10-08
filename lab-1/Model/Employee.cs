using System;

namespace lab1.Model
{
    public class Employee : User
    {
        public Company Company { get; set; }

        public override void Display()
        {
            Console.WriteLine($"Здравствуйте, меня зовут {FullName}, я занимаю позицию \"{JobTitle}\" в компании \"{Company.Name}\" ({Company.Country}, {Company.City}, {Company.Address}) и моя зарплата {JobSalary}.");
        }
    }
}
