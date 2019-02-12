using System.Collections;
using System.IO;

namespace Grades
{
    internal interface IGradeTracker : IEnumerable
    {
        // can't use access keywords here
        // automatically virtual
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrade(TextWriter destination);
        string Name { get; set; }
    }
}