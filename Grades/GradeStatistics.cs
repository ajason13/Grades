namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }

        // Holding Alt + Click = free form select
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }
}