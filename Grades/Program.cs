using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            // Need this in all my programs now. Probably run in async tho
            /*
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello! This is the grade book program");
            */

            //GradeBook book = CreateGradeBook();
            IGradeTracker book = CreateGradeBook();
            GetBookName(book);

            //book.NameChanged += OnNameChanged;

            // Since book.NameChanged has event keyword, no need for new NameChangedDelegate();
            //book.NameChanged += new NameChangedDelegate(OnNameChanged);
            //book.NameChanged += new NameChangedDelegate(OnNameChanged2);

            // Bit confusing unless you know C#. -____-
            // Delegate updated to use sender object and eventargs
            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged2;

            book.Name = "Grade Book";
            book.Name = "Bob's Grade Book";
            AddGrades(book);

            // Console.Out helps write to ouput (Ex. Screen, File, etc)
            //book.WriteGrade(Console.Out);

            SaveGrade(book);
            WriteResults(book);
        }

        // Factory method so code won't limit itself to 1 type of GradeBook. (If have multiple derived GradeBooks)
        // Get program to work with base class GradeBook, but have different behavior depending on which derived GradeBook is created
        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            // When using interfaces and need to enumerate from derived class, parent class needs to be child of IEnumerable
            foreach(float grade in book)
            {
                Console.WriteLine(grade);
            }

            Console.WriteLine(book.Name);
            // cw + 2x Tab = Console.WriteLine();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.AverageGrade);
            //WriteResult("Lowest", (int) stats.LowestGrade, 2, 3, 4);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.LetterGradeDescription, stats.LetterGrade);
        }

        private static void SaveGrade(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrade(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a Name: ");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Method assigned to delegate
        static void OnNameChanged(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        /*
        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Grade book changing name from {existingName} to {newName}");
        }

        
        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("***");
        }
        */

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

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
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
// - Common for desktop/mobile apps

// Delegates
// - Variable that reference a method
// - Can concatenate multiple methods into delegate using '+='
// - Can remove methods into delegate using '-='
// - Good use is for when a variable changes, execute a method.
// - Good use for buttons
// - Good use for building UI
// - Ex. public delegate void Writer(string message);
// -     ...
// -     Logger logger = new Logger();
// -     Writer writer = new Writer(logger.WriteMessage);   // WriteMessage is a method.
// -     writer("Success!!");                               // Can only pass method that'll return same type as delegate and pass same parameter type as delegate

// Back to Events
// - Events based on delegates
// - Add event keyword to instanced delegate
// - This allows delegates to not be null or be reassigned. Only add/remove deletegates/subscribers
// - When instanced delegate is event, then dont need to instantiate delegate in program.
// - Convention for creating delegates
//      - Always pass 2 parameters
//      - 1st param is sender of event (Ex. If GradeBook announcing name change, pass in GradeBook) [Ex. object sender]
//          - Passing object will allow to pass in anything (Ex. int, string, GradeBook instance, etc)
//      - 2nd param is all information needed about that event (usually a class)
//          - Name of class should be delegate name + "EventArgs"
//          - Inherits EventArgs class also

// Branching
// - Short hand if/else supported. (Ex. string pass = age > 20 ? "pass" : "nopass";

// Can use empty return to break out of void method

// Throwing (Execption)
// - Ex. if (age == 21)
//          throw new ArgumentException("21 is not a legal value");

// Handling Exception
// - Use Try-Catch block
// - When chaining exceptions, include specific exceptions up top
// - Use Finally block to close out resources that might throw an exception
//      - Use using statement to instead of open and close statement for resources
//      - Compile will add closing statements after code block under using statment(s) is completed
//      - Ex. using(FileStream file1 = new FileStream("in.txt", FileMode.Open)
//            using(FileStream file2 = new FileStream("out.txt", FileMode.Create))
//            {
//                  // Code to work with files
//            }
// - When managing IO operations, use using statement
//      - A good indicator if using statment block is needed is if a class has a Dispose() method

// If refactoring to another method, highlihght statements, Ctrl + ., and enter
// After method name is finalized, press enter will rename method in class

// Obejct Oriented Programming
// - Encapsulation - hide complexity
// - Inheritance (Overrated) - resusable code with parent/child relationship
// - Polymorphism (Overrated) - many shapes. Objects have different behavior depending on type.
//      - To properly override methods, base method must have virtual keyword and derived method must have override keyword
// - Abstract Class
//      - Better version of inheritance
//      - Can have virutal methods/variables
//      - For methods with abstract keyword, derived class needs to fill out logic of method
//      - Drived class can only have 1 parent class
// - Interfaces
//      - No implementation details
//      - Type can inherit multiple interfaces
//      - If deciding between abstract class and interface, prefer interface
//      - If have type starts with 'I' and Ctrl + ., can generate interface
//      - Important Interfaces
//          - IDisposable - release resources (file, connection, etc)
//          - IEnumerable - supports iteration (foreach) [All collection classes implement IEnumerable interface]
//          - INotifyPropertyChange - raise events when properties change   
//          - IComparable - compares for sorting
