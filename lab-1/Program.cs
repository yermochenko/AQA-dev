using Bogus;
using lab1.Model;
using System;
using System.Collections.Generic;

namespace lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            var dismissalReason = Enum.GetValues(typeof(DismissalReason));
            var candidates = new Faker<Candidate>("ru")
                .RuleFor(candidate => candidate.Id, f => f.Random.Guid())
                .RuleFor(candidate => candidate.FirstName, f => f.Person.FirstName)
                .RuleFor(candidate => candidate.LastName, f => f.Person.LastName)
                .RuleFor(candidate => candidate.JobTitle, f => f.Name.JobTitle())
                .RuleFor(candidate => candidate.JobDescription, f => f.Name.JobDescriptor())
                .RuleFor(candidate => candidate.JobSalary, f => f.Random.Int(1, 20) * 100)
                .RuleFor(candidate => candidate.DismissalReason, f =>
                {
                    var index = f.Random.Int(0, dismissalReason.Length);
                    if (index < dismissalReason.Length)
                    {
                        return dismissalReason.GetValue(index);
                    }
                    else
                    {
                        return null;
                    }
                })
                .Generate(random.Next(10, 20));
            Console.WriteLine($"***** КАНДИДАТЫ (всего {candidates.Count}) *****\n");
            foreach (var candidate in candidates)
            {
                candidate.Output();
                Console.WriteLine();
            }

            var companies = new Faker<Company>("ru")
                .RuleFor(company => company.Name, faker => faker.Company.CompanyName())
                .RuleFor(company => company.Country, faker => faker.Address.Country())
                .RuleFor(company => company.City, faker => faker.Address.City())
                .RuleFor(company => company.Address, faker => faker.Address.StreetAddress())
                .Generate(random.Next(3, 7));
            var employees = new Faker<Employee>("ru")
                .RuleFor(employee => employee.Id, f => f.Random.Guid())
                .RuleFor(employee => employee.FirstName, f => f.Person.FirstName)
                .RuleFor(employee => employee.LastName, f => f.Person.LastName)
                .RuleFor(employee => employee.JobTitle, f => f.Name.JobTitle())
                .RuleFor(employee => employee.JobDescription, f => f.Name.JobDescriptor())
                .RuleFor(employee => employee.JobSalary, f => f.Random.Int(1, 20) * 100)
                .RuleFor(employee => employee.Company, f => companies[f.Random.Int(0, companies.Count - 1)])
                .Generate(random.Next(10, 20));
            Console.WriteLine($"***** СОТРУДНИКИ (всего {employees.Count}) *****\n");
            foreach (var employee in employees)
            {
                employee.Output();
            }
        }
    }
}
