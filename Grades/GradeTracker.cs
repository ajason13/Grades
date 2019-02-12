using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        // Public member -> uppercase letter
        // If serializing property (Ex. XML, JSON, etc), some frameworks only look at properties instead of fields
        // Databinding only looks at Properties
        // Make public fields into Properties with uppercase first letter
        // prop + 2x Tab = set property
        //public string Name { get; set; }
        protected string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value && NameChanged != null)
                {
                    NameChangeEventArgs args = new NameChangeEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    // this keyword - inside every non-static method, this keyword represents object method is inside of
                    NameChanged(this, args);

                    // Updated delegate to use sender and event args
                    //NameChanged(_name, value);
                }
                _name = value;
            }
        }

        public event NameChangedDelegate NameChanged;

        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrade(TextWriter destination);

        public abstract IEnumerator GetEnumerator();
    }
}
