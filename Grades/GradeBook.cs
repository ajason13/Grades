using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        // Private/Protected members -> lowercase letter
        // Protected allows access in derived class
        protected List<float> grades;
        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        // ctor + 2x tab = constructor
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        // Since out is reserve keyword, VS used @ symbol. @ used for names that use keywords [AVOID]
        //public void WriteGrade(TextWriter @out)

        // TextWriter can write out to Console, File, Network, etc)
        public override void WriteGrade(TextWriter destination)
        {
            // for + 2x Tab = for loop
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }
        
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        // Program will now see which object is created at runtime to decide on which ComputeStatistics to use
        //public virtual GradeStatistics ComputeStatistics()
        // Since GradeTracker has abstract ComputeStatistics, need to use override keyword
        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach(float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;

            return stats;
        }
    }
}
