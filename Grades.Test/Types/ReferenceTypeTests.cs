using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grades;

namespace Grades.Test.Types
{
    // Ctrl + . = Open lightbulb for corrects
    [TestClass]
    public class ReferenceTypeTests
    {
        [TestMethod]
        public void GradeBookVariablesHoldsAReference()
        {
            // F12 to go to source code of something (Ex. Gradebook goes to Gradebook.cs)
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;
            
            g1.Name = "Jason's grade book";
            Assert.AreEqual(g1.Name, g2.Name);
        }

        //testm + 2x Tab = Test Method
        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Scott";
            string name2 = "scott";

            bool result = String.Equals(name1, name2, StringComparison.CurrentCultureIgnoreCase);
            Assert.IsTrue(result);
        }
    }
}
