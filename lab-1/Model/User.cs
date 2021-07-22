using System;

namespace lab1.Model
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + ' ' + LastName;
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public int JobSalary { get; set; }
    }
}
