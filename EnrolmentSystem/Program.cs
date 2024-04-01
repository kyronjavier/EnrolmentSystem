using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnrolmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Testing Subject All arg constructor
            Subject studentSubject = new Subject("WBC123", "Programming", 79.99);
            Console.WriteLine("Testing Subject all arg: ");
            Console.WriteLine(studentSubject + "\n");

            //Testing Enrollment All arg constructor
            Enrollment studentEnrollment = new Enrollment(DateTime.Now, "PA", "Semester 1", studentSubject);
            Console.WriteLine("Testing Enrollment all arg: ");
            Console.WriteLine(studentEnrollment + "\n");

            // Testing Address All arg constructor
            Address studentAddress = new Address("321", "Queen Street", "Mawson Lakes", "1423", "SA");
            Console.WriteLine("Testing Address all arg: ");
            Console.WriteLine(studentAddress);

            // Testing Person All arg constructor
            Person studentPerson = new Person("Kyle Javier", "kyle@email.com", "12345678", studentAddress);
            Console.WriteLine("Testing Person all arg: ");
            Console.WriteLine(studentPerson);

            // Testing Student All arg constructor
            Console.WriteLine("Testing Student all arg: ");
            //Person Person = new Person();
            Student student = new Student("123456", "Computer Science", DateTime.Now, studentEnrollment);
            Console.WriteLine(student);


            // Testing Equals Methods

            Enrollment studentEnrollment2 = new Enrollment(DateTime.Now, "PA", "Semester 1");

            Student student1 = new Student("1234567", "Engineering", DateTime.Now, studentEnrollment);

            Student student2 = new Student("1928344", "Information Technology", DateTime.Now, studentEnrollment2);

            Student student3 = new Student("1234567", "Engineering", DateTime.Now, studentEnrollment);

            Console.WriteLine();

            //Console.WriteLine("Student 1 == Student 2: " + (student1 == student2)); // false
            //Console.WriteLine("Student 1 == Student 2: " + (student1.Equals(student2))); // false
            //Console.WriteLine("Student 1 != Student 2: " + (student1 != student2)); // true
            //Console.WriteLine("Student 1 == Student 3: " + (student1 == student3)); // true
            //Console.WriteLine("Student 1 == Student 3: " + (student1.Equals(student3))); // true
            //Console.WriteLine("Student 1 != Student 3: " + (student1 != student3)); // false

            Console.WriteLine("\nTest Equals Method:\n");
            Console.WriteLine("student1.Equals(student2) (Expected False): " + student1.Equals(student2));
            Console.WriteLine("student1.Equals(student3) (Expected True): " + student1.Equals(student3));


            Console.WriteLine("\nTest overridden operators: (==) and (!=)\n");

            Console.WriteLine("student1 != student2 (Expected True): " + (student1 != student2));
            Console.WriteLine("student1 == student3 (Expected True): " + (student1 == student3));

            Console.WriteLine("\nTesting GetHashCode for all 3 students:\n ");

            Console.WriteLine("Hash code of Student 1: " + student1.GetHashCode());
            Console.WriteLine("Hash code of Student 2: " + student2.GetHashCode());
            Console.WriteLine("Hash code of Student 3: " + student3.GetHashCode());

            // Test Bubble sort ascending

            Enrollment[] enrollments = new Enrollment[]
            {
                new Enrollment(DateTime.Now, "PA", "Semester 1"),
                new Enrollment(DateTime.Now, "FA", "Semester 3"),
                new Enrollment(DateTime.Now, "PA", "Semester 2"),
                new Enrollment(DateTime.Now, "PA", "Semester 2"),
                new Enrollment(DateTime.Now, "PA", "Semester 2"),
                new Enrollment(DateTime.Now, "FA", "Semester 3"),
                new Enrollment(DateTime.Now, "PA", "Semester 1"),
                new Enrollment(DateTime.Now, "PA", "Semester 3"),
                new Enrollment(DateTime.Now, "PA", "Semester 2"),
                new Enrollment(DateTime.Now, "FA", "Semester 1"),
            };

            Student[] students = new Student[]
            {
                new Student("001172631", "Computer Science", DateTime.Now, enrollments[0]),
                new Student("001172632", "Computer Engineering", DateTime.Now, enrollments[1]),
                new Student("001172633", "Medical Science", DateTime.Now, enrollments[2]),
                new Student("001172634", "Hospitality Management", DateTime.Now, enrollments[3]),
                new Student("001172635", "Mechanical Engineering", DateTime.Now, enrollments[4]),
                new Student("001172636", "Law", DateTime.Now, enrollments[5]),
                new Student("001172637", "Journalism", DateTime.Now, enrollments[6]),
                new Student("001172638", "Information Technology", DateTime.Now, enrollments[7]),
                new Student("001172639", "Aeronautics", DateTime.Now, enrollments[8]),
                new Student("001172630", "Computer Science", DateTime.Now, enrollments[9]),

        };

            students[0].Name = "Xavier";
            students[1].Name = "Kyle";
            students[2].Name = "Aaron";
            students[3].Name = "Ian";
            students[4].Name = "Ivan";
            students[5].Name = "Carlo";
            students[6].Name = "Heidi";
            students[7].Name = "Reyka";
            students[8].Name = "Shayne";
            students[9].Name = "Angelica";


            Utility.BubbleSortDescending(students);
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].Name);
            }
            Utility.BubbleSortAscending(students);

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].Name);
            }
            Console.WriteLine(students);

            Console.ReadKey();

        }
    }
}
