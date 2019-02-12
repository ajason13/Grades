using System;

namespace Grades
{
    public class GradeStatistics
    {
        // Holding Alt + Click = free form select
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;

        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }

        public string LetterGrade
        {
            get
            {
                double roundedAverageGrade = Math.Round(AverageGrade);
                string returnGrade;
                if (roundedAverageGrade >= 90)
                {
                    returnGrade = "A";
                }
                else if (roundedAverageGrade >= 80)
                {
                    returnGrade = "B";
                }
                else if (roundedAverageGrade >= 70)
                {
                    returnGrade = "C";
                }
                else if (roundedAverageGrade >= 60)
                {
                    returnGrade = "D";
                }
                else
                {
                    returnGrade = "F";
                }
                return returnGrade;
            }
        }

        public string LetterGradeDescription
        {
            get
            {
                string returnLetterGradeDescription;
                switch (LetterGrade)
                {
                    case "A":
                        returnLetterGradeDescription = "Excellent";
                        break;
                    case "B":
                        returnLetterGradeDescription = "Good";
                        break;
                    case "C":
                        returnLetterGradeDescription = "Average";
                        break;
                    case "D":
                        returnLetterGradeDescription = "Below Average";
                        break;
                    default:
                        returnLetterGradeDescription = "Failing";
                        break;
                }
                return returnLetterGradeDescription;
            }
        }
    }
}