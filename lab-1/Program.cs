using lab1.Model;
using System;
using System.Collections.Generic;

namespace lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var candidates = new List<Candidate>()
            {
                new Candidate() { Id = Guid.NewGuid(), FirstName = "Иван",    LastName = "Иванов",       JobTitle = "Программист",   JobDescription = "Junior .Net разработчик",           JobSalary = 500,   DismissalReason = null },
                new Candidate() { Id = Guid.NewGuid(), FirstName = "Вера",    LastName = "Александрова", JobTitle = "Тестировщик",   JobDescription = "Senior тестировщик-автоматизатор",  JobSalary = 2_000, DismissalReason = DismissalReason.LackManagementUnderstanding },
                new Candidate() { Id = Guid.NewGuid(), FirstName = "Пётр",    LastName = "Петров",       JobTitle = "Администратор", JobDescription = "Senior DBA",                        JobSalary = 5_000, DismissalReason = DismissalReason.LowSalary },
                new Candidate() { Id = Guid.NewGuid(), FirstName = "Надежда", LastName = "Николаева",    JobTitle = "Программист",   JobDescription = "Middle JavaScript разработчик",     JobSalary = 950,   DismissalReason = DismissalReason.ProfessionalGrowthLack },
                new Candidate() { Id = Guid.NewGuid(), FirstName = "Сидор",   LastName = "Сидоров",      JobTitle = "Тестировщик",   JobDescription = "Middle мануальный тестировщик",     JobSalary = 750,   DismissalReason = DismissalReason.FamilyReasons },
                new Candidate() { Id = Guid.NewGuid(), FirstName = "Любовь",  LastName = "Сергеева",     JobTitle = "Аналитик",      JobDescription = "Senior бизнес-аналитик",            JobSalary = 3_500, DismissalReason = DismissalReason.BadTeamMicroclimate },
                new Candidate() { Id = Guid.NewGuid(), FirstName = "Василий", LastName = "Васильев",     JobTitle = "Программист",   JobDescription = "Senior .Net fullstack разработчик", JobSalary = 4_000, DismissalReason = DismissalReason.Other }
            };
            Console.WriteLine("***** КАНДИДАТЫ *****\n");
            foreach (var candidate in candidates)
            {
                candidate.Output();
                Console.WriteLine();
            }
            var corporationOfGood = new Company() { Name = "Ганди & Co",        Country = "Индия",  City = "Дели",   Address = "ул. Многорукого Шивы, д. 6, корп. 6, оф. 6" };
            var corporationOfEvil = new Company() { Name = "Иван Грозный Inc.", Country = "Россия", City = "Москва", Address = "ул. Ленина, д. 13" };
            var employees = new List<Employee>()
            {
                new Employee() { Id = Guid.NewGuid(), FirstName = "Иван",     LastName = "Иванов",       JobTitle = "Программист",   JobDescription = "Junior .Net разработчик",           JobSalary = 500,   Company = corporationOfEvil },
                new Employee() { Id = Guid.NewGuid(), FirstName = "Вера",     LastName = "Александрова", JobTitle = "Тестировщик",   JobDescription = "Senior тестировщик-автоматизатор",  JobSalary = 2_000, Company = corporationOfEvil },
                new Employee() { Id = Guid.NewGuid(), FirstName = "Пётр",     LastName = "Петров",       JobTitle = "Администратор", JobDescription = "Senior DBA",                        JobSalary = 5_000, Company = corporationOfEvil },
                new Employee() { Id = Guid.NewGuid(), FirstName = "Надежда",  LastName = "Николаева",    JobTitle = "Программист",   JobDescription = "Middle JavaScript разработчик",     JobSalary = 950,   Company = corporationOfEvil },
                new Employee() { Id = Guid.NewGuid(), FirstName = "Сидор",    LastName = "Сидоров",      JobTitle = "Тестировщик",   JobDescription = "Middle мануальный тестировщик",     JobSalary = 750,   Company = corporationOfEvil },
                new Employee() { Id = Guid.NewGuid(), FirstName = "Любовь",   LastName = "Сергеева",     JobTitle = "Аналитик",      JobDescription = "Senior бизнес-аналитик",            JobSalary = 3_500, Company = corporationOfEvil },
                new Employee() { Id = Guid.NewGuid(), FirstName = "Василий",  LastName = "Васильев",     JobTitle = "Программист",   JobDescription = "Senior .Net fullstack разработчик", JobSalary = 4_000, Company = corporationOfEvil },
                new Employee() { Id = Guid.NewGuid(), FirstName = "Готама",   LastName = "Капур",        JobTitle = "Программист",   JobDescription = "Junior Java разработчик",           JobSalary = 275,   Company = corporationOfGood },
                new Employee() { Id = Guid.NewGuid(), FirstName = "Нитья",    LastName = "Абусария",     JobTitle = "Тестировщик",   JobDescription = "Junior мануальный тестировщик",     JobSalary = 215,   Company = corporationOfGood },
                new Employee() { Id = Guid.NewGuid(), FirstName = "Серендра", LastName = "Джутхани",     JobTitle = "Администратор", JobDescription = "Middle системный инженер",          JobSalary = 425,   Company = corporationOfGood },
                new Employee() { Id = Guid.NewGuid(), FirstName = "Амрита",   LastName = "Бхаттар",      JobTitle = "Тестировщик",   JobDescription = "Middle мануальный тестировщик",     JobSalary = 375,   Company = corporationOfGood },
                new Employee() { Id = Guid.NewGuid(), FirstName = "Ананта",   LastName = "Варма",        JobTitle = "Программист",   JobDescription = "Middle Java fullstack разработчик", JobSalary = 500,   Company = corporationOfGood }
            };
            Console.WriteLine("***** СОТРУДНИКИ *****\n");
            foreach (var employee in employees)
            {
                employee.Output();
            }
        }
    }
}
