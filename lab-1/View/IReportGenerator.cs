using lab1.Model;
using System.Collections.Generic;

namespace lab1.View
{
    public interface IReportGenerator<T> where T : User
    {
        void OutputReport(List<T> users);
    }
}
