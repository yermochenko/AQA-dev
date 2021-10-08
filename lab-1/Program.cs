using lab1.Generator;
using lab1.Model;
using lab1.View;
using System;

namespace lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();

            var candidates = UserFactory.NewInstance<Candidate>(random.Next(10, 20));
            Console.WriteLine($"***** КАНДИДАТЫ (всего {candidates.Count}) *****\n");
            foreach (var candidate in candidates)
            {
                candidate.Display();
                Console.WriteLine();
            }

            Console.WriteLine("***** ОТЧЁТ ПО КАНДИДАТАМ *****");
            new CandidateReportGenerator().OutputReport(candidates);

            var employees = UserFactory.NewInstance<Employee>(random.Next(10, 20));
            Console.WriteLine($"***** СОТРУДНИКИ (всего {employees.Count}) *****\n");
            foreach (var employee in employees)
            {
                employee.Display();
            }

            Console.WriteLine("***** ОТЧЁТ ПО СОТРУДНИКАМ *****");
            new EmployeeReportGenerator().OutputReport(employees);
        }
    }
}
