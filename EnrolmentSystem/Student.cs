using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrolmentSystem
{
    /// <summary>
    /// Represents a student with studentID, program, and dateRegistered
    /// </summary>

    public class Student : Person , IComparable<Student>
    {
        public const string DEF_STUDENT_ID = "N/A";
        public const string DEF_PROGRAM = "Undeclared";


        public string StudentID { get; set; }
        public string StudentProgram { get; set; }
        public DateTime DateRegistered { get; set; }
        public Enrollment StudentEnrollment { get; set; }

        public Student(): this(DEF_STUDENT_ID, DEF_PROGRAM, DateTime.Now)
        {
        }
        /// <summary>
        /// Updated the old all arg to call the new all arg with default enrollment
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="studentProgram"></param>
        /// <param name="dateRegistered"></param>
        public Student(string studentID, string studentProgram, DateTime dateRegistered) : this(studentID, studentProgram, dateRegistered, new Enrollment()) { }
        
        /// <summary>
        /// New all arg constructor with enrollment object
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="studentProgram"></param>
        /// <param name="dateRegistered"></param>
        /// <param name="enrollment"></param>
        public Student(string studentID, string studentProgram, DateTime dateRegistered, Enrollment enrollment)
        : base()
        {
            StudentID = studentID;
            StudentProgram = studentProgram;
            DateRegistered = dateRegistered;
            StudentEnrollment = enrollment;
        }
        /// <summary>
        /// Displays the ToString method
        /// </summary>
        /// <returns> a formatted information of a student </returns>
        public override string ToString()
        {
            return $"{base.ToString()} [Student ID: {StudentID}, Program: {StudentProgram}, Date Registered: {DateRegistered}, Enrollment: {StudentEnrollment}]";
        }
        /// <summary>
        /// overriding the equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Student other = (Student)obj;
            return this.StudentID == other.StudentID;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Student other)
        {
            return StudentID.CompareTo(other.StudentID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator > (Student a, Student b)
        {
            return a.StudentID.CompareTo(b.StudentID) >0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <(Student a, Student b)
        {
            return a.StudentID.CompareTo(b.StudentID) < 0;
        }
        /// <summary>
        /// Overriding equal operators
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>if two objects are equal</returns>
        public static bool operator ==(Student a, Student b)
        {
            if (object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.StudentID == b.StudentID;
        }
        /// <summary>
        /// overriding not equal operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>if two objects are not equal</returns>
        public static bool operator != (Student a, Student b)
        {
            return !object.Equals(a, b);
        }
        /// <summary>
        /// get hash method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.StudentID.GetHashCode() ^ this.StudentProgram.GetHashCode();
        }
    }
}
