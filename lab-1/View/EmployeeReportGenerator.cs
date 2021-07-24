using lab1.Model;
using System;
using System.Collections.Generic;

namespace lab1.View
{
    public class EmployeeReportGenerator : IReportGenerator<Employee>
    {
        public void OutputReport(List<Employee> employees)
        {
            employees.Sort((employee1, employee2) =>
            {
                var result = employee1.Company.Name.CompareTo(employee2.Company.Name);
                if (result == 0)
                {
                    result = employee2.JobSalary.CompareTo(employee1.JobSalary);
                }
                return result;
            });
            foreach (var employee in employees)
            {
                Console.WriteLine($"| {employee.Id} | {employee.Company.Name,-40} | {employee.FullName,-40} | {employee.JobSalary,-10} |");
            }
        }
    }
}
