﻿using lab1.Model;
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
            foreach(var candidate in candidates)
            {
                Console.WriteLine($"| {candidate.Id} | {candidate.FullName, -17} | {candidate.JobTitle, -13} | {candidate.JobDescription, -33} | {candidate.JobSalary, -7:#,# $} | {candidate.DismissalReason, -27} |");
            }
        }
    }
}
