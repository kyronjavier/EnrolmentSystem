using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrolmentSystem
{
    internal class Subject
    {
        public const string DEFAULT_SUBJECT_CODE = "Not Provided";
        public const string DEFAULT_SUBJECT_NAME = "N/A";
        public const double DEFAULT_COST = 0.0;

        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public double Cost { get; set; }

        public Subject(): this (DEFAULT_SUBJECT_CODE, DEFAULT_SUBJECT_NAME, DEFAULT_COST)
        {
        }

        public Subject(string subjectCode, string subjectName, double cost)
        {
            SubjectCode = subjectCode;
            SubjectName = subjectName;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"{SubjectCode} - {SubjectName}, Cost: ${Cost}";
        }
    }
}
