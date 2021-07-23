using System;
using System.Collections.Generic;

namespace lab1.Model
{
    public class Candidate : User
    {
        public DismissalReason? DismissalReason { get; set; }

        private static readonly Dictionary<DismissalReason, string> dismissalReasonNames = new Dictionary<DismissalReason, string>()
        {
            [lab1.Model.DismissalReason.FamilyReasons] = "семейная ситуация",
            [lab1.Model.DismissalReason.ProfessionalGrowthLack] = "отсутствие профессионального роста",
            [lab1.Model.DismissalReason.LowSalary] = "низкая заработная плата",
            [lab1.Model.DismissalReason.BadTeamMicroclimate] = "плохой микроклимат в коллективе",
            [lab1.Model.DismissalReason.LackManagementUnderstanding] = "отсутствие взаимопонимания с руководством",
            [lab1.Model.DismissalReason.Other] = "ситуация, о которой не хотелось бы говорить"
        };

        public override void Output()
        {
            Console.WriteLine($"Здравствуйте, меня зовут {FullName}.");
            Console.WriteLine($"Я хочу работать на позиции \"{JobTitle}\" ({JobDescription}) с зарплатой от {JobSalary}.");
            if (DismissalReason is lab1.Model.DismissalReason dismissalReason)
            {
                Console.WriteLine($"Я уволился с предыдущего места работы по следующей причине: {dismissalReasonNames[dismissalReason]}.");
            }
            else
            {
                Console.WriteLine("Я нигде не работал до этого.");
            }
        }
    }
}
