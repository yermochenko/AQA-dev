using Bogus;
using lab1.Model;
using System;
using System.Collections.Generic;

namespace lab1.Generator
{
    public class UserFactory
    {
        private static readonly Dictionary<Type, object> generators = new Dictionary<Type, object>()
        {
            [typeof(Candidate)] = new CandidateGenerator(),
            [typeof(Employee)] = new EmployeeGenerator()
        };

        public static T NewInstance<T>() where T : User
        {
            return ((UserGenerator<T>)generators[typeof(T)]).Generate();
        }

        public static List<T> NewInstance<T>(int count) where T : User
        {
            return ((UserGenerator<T>)generators[typeof(T)]).Generate(count);
        }

        private UserFactory() { }

        private abstract class UserGenerator<U> : Faker<U> where U : User
        {
            public UserGenerator() : base("ru")
            {
                RuleFor(user => user.Id, f => f.Random.Guid());
                RuleFor(user => user.FirstName, f => f.Person.FirstName);
                RuleFor(user => user.LastName, f => f.Person.LastName);
                RuleFor(user => user.JobTitle, f => f.Name.JobTitle());
                RuleFor(user => user.JobDescription, f => f.Name.JobDescriptor());
                RuleFor(user => user.JobSalary, f => f.Random.Int(1, 20) * 100);
            }
        }

        private class CandidateGenerator : UserGenerator<Candidate>
        {
            public CandidateGenerator()
            {
                var dismissalReason = Enum.GetValues(typeof(DismissalReason));
                RuleFor(candidate => candidate.DismissalReason, f =>
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
                });
            }
        }

        private class EmployeeGenerator : UserGenerator<Employee>
        {
            private static readonly List<Company> companies = CompanyFactory.GenerateCompany(new Random().Next(3, 7));

            public EmployeeGenerator()
            {
                RuleFor(employee => employee.Company, f => companies[f.Random.Int(0, companies.Count - 1)]);
            }
        }
    }
}
