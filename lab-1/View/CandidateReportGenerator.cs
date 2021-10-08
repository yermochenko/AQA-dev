using lab1.Model;
using System;
using System.Collections.Generic;

namespace lab1.View
{
    public class CandidateReportGenerator : IReportGenerator<Candidate>
    {
        public void GenerateReport(List<Candidate> candidates)
        {
            candidates.Sort((candidate1, candidate2) =>
            {
                var result = candidate1.JobTitle.CompareTo(candidate2.JobTitle);
                if (result == 0)
                {
                    result = candidate1.JobSalary.CompareTo(candidate2.JobSalary);
                }
                return result;
            });
            foreach (var candidate in candidates)
            {
                Console.WriteLine($"| {candidate.Id} | {candidate.JobTitle,-50} | {candidate.FullName,-40} | {candidate.JobSalary,-10} |");
            }
        }
    }
}
