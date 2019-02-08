using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello! This is the grade book program");

            GradeBook book = new GradeBook();
            book.Name = "Grade Book";
            book.Name = null;
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);

            // cw + 2x Tab = Console.WriteLine();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int) stats.AverageGrade);
            //WriteResult("Lowest", (int) stats.LowestGrade, 2, 3, 4);
            WriteResult("Lowest", stats.LowestGrade);
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        //static void WriteResult(string description, params float[] result)
        static void WriteResult(string description, float result)
        {
            //Console.WriteLine(description + ": " + result);

            // String formmatting easier than string concat
            // F2 = 2 decimal places
            // C = Currency ($xx.xx)
            //Console.WriteLine("{0}: {1:F2}", description, result);

            // String interpolation for easier viewing
            // Need $ infront of double quotes
            Console.WriteLine($"{description}: {result:F2}");
        }
    }
}

// Create structs when representing a single value (Ex. points on graph, currency, DateTime, etc)
// Structss should be small

// Use enums for named constants

// Default access for method is private (AKA omit access word)
// - Internal - Make method/class available to code in Project

// params keyword in function paramter allows n amounts of params. Needs to be last paramter in signature and will result in object[].

// Fields
// - private fields have _ as preffix (Ex. _animal) and has readonly keyword

// Properties
// - Getters and Setters
// - Use setter to check if valid value to enter (Ex. check for null in setter)

// Events
// - Send notifications to other classes or objects
// - Publisher raises event and subscriber(s) process event