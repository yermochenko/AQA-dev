using Bogus;
using lab1.Model;
using System.Collections.Generic;

namespace lab1.Generator
{
    public class CompanyFactory
    {
        private static readonly CompanyGenerator companyGenerator = new CompanyGenerator();

        public static Company GenerateCompany()
        {
            return companyGenerator.Generate();
        }

        public static List<Company> GenerateCompany(int count)
        {
            return companyGenerator.Generate(count);
        }

        private class CompanyGenerator : Faker<Company>
        {
            public CompanyGenerator() : base("ru")
            {
                RuleFor(company => company.Name, faker => faker.Company.CompanyName());
                RuleFor(company => company.Country, faker => faker.Address.Country());
                RuleFor(company => company.City, faker => faker.Address.City());
                RuleFor(company => company.Address, faker => faker.Address.StreetAddress());
            }
        }
    }
}
