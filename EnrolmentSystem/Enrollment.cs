using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrolmentSystem
{
    public class Enrollment
    {
        const string DEF_GRADE = "N/A";
        const string DEF_SEMESTER = "Not provided";

        public DateTime DateEnrolled { get; set; }
        public string Grade { get; set; }
        public string Semester { get; set; }
        public Subject Subject { get; set; }

        public Enrollment() : this(DateTime.Now, DEF_GRADE, DEF_SEMESTER)
        {
        }

        public Enrollment(DateTime dateEnrolled, string grade, string semester) : this(dateEnrolled, grade, semester, new Subject()) { }

        public Enrollment(DateTime dateEnrolled, string grade, string semester, Subject subject)
        {
            DateEnrolled = dateEnrolled;
            Grade = grade;
            Semester = semester;
            Subject = subject;
        }

        public override string ToString()
        {
            return $"{Subject} - Enrolled on: {DateEnrolled}, Grade: {Grade}, Semester: {Semester}";
        }
    }
}
