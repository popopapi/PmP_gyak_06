using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmP_gyak_06
{
    class Person
    {
        public int Seqn { get; private set; }
        public string Survey { get; private set; }
        public int Gender { get; private set; } 
        public int Age { get; private set; }
        public double Bmi { get; private set; }
        public double Glucose { get; private set; }

        public Person(int seqn, string survey, int gender, int age, double bmi, double glucose)
        {
            Seqn = seqn;
            Survey = survey;
            Gender = gender;
            Age = age;
            Bmi = bmi;
            Glucose = glucose;
        }
    }
}
