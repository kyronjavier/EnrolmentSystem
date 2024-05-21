using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EnrolmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Testing Subject All arg constructor
            Subject studentSubject = new Subject("WBC123", "Programming", 79.99);
            Console.WriteLine("Testing Subject all arg: ");
            Console.WriteLine(studentSubject + "\n");

            // Testing Enrollment All arg constructor
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
            Address yohanAddress = new Address("987", "King Street", "Pooraka", "4132", "SA");
            Student student = new Student("Yohan", "yohan@email.com", "0432456798", yohanAddress, "123456", "Computer Science", DateTime.Now, studentEnrollment);
            Console.WriteLine(student);

            // Testing Equals Methods
            Enrollment studentEnrollment2 = new Enrollment(DateTime.Now, "PA", "Semester 1");

            Address student1Address = new Address("123", "Elizabeth Street", "Mawson Lakes", "0987", "SA");
            Student student1 = new Student("Kyle", "kyle@email.com", "0499876543", student1Address, "1234567", "Engineering", DateTime.Now, studentEnrollment);

            Address student2Address = new Address("345", "Herrera Street", "Parafield Gardens", "9876", "SA");
            Student student2 = new Student("Aaron", "aaron@email.com", "0412345678", student2Address, "1928344", "Information Technology", DateTime.Now, studentEnrollment2);

            Address student3Address = new Address("456", "Barcelona Street", "Enfield", "8765", "SA");
            Student student3 = new Student("Kyron", "kyron@email.com", "0498765432", student3Address, "1234567", "Engineering", DateTime.Now, studentEnrollment);

            Console.WriteLine();

            // Console.WriteLine("Student 1 == Student 2: " + (student1 == student2)); // false
            // Console.WriteLine("Student 1 == Student 2: " + (student1.Equals(student2))); // false
            // Console.WriteLine("Student 1 != Student 2: " + (student1 != student2)); // true
            // Console.WriteLine("Student 1 == Student 3: " + (student1 == student3)); // true
            // Console.WriteLine("Student 1 == Student 3: " + (student1.Equals(student3))); // true
            // Console.WriteLine("Student 1 != Student 3: " + (student1 != student3)); // false

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

            Address[] addresses = new Address[]
            {
                new Address("123", "Street1", "Suburb1", "1234", "SA"),
                new Address("234", "Street2", "Suburb2", "2345", "SA"),
                new Address("345", "Street3", "Suburb3", "3456", "SA"),
                new Address("456", "Street4", "Suburb4", "4567", "SA"),
                new Address("567", "Street5", "Suburb5", "5678", "SA"),
                new Address("789", "Street6", "Suburb6", "6789", "SA"),
                new Address("890", "Street7", "Suburb7", "7890", "SA"),
                new Address("901", "Street8", "Suburb8", "9012", "SA"),
                new Address("012", "Street9", "Suburb9", "0123", "SA"),
                new Address("102", "Street10", "Suburb10", "1029", "SA")
            };

            Student[] students = new Student[]
            {
                new Student("Kyle", "kyle@email.com", "0987654321", addresses[0], "001172631", "Computer Science", DateTime.Now, enrollments[0]),
                new Student("Aaron", "aaron@email.com", "0987654321", addresses[1], "001172632", "Computer Engineering", DateTime.Now, enrollments[1]),
                new Student("Angelica", "angelica@email.com", "0987654321", addresses[2], "001172633", "Medical Science", DateTime.Now, enrollments[2]),
                new Student("Xavier", "xavier@email.com", "0987654321", addresses[3], "001172634", "Hospitality Management", DateTime.Now, enrollments[3]),
                new Student("Maria", "maria@email.com", "0987654321", addresses[4], "001172635", "Mechanical Engineering", DateTime.Now, enrollments[4]),
                new Student("Jericho", "jericho@email.com", "0987654321", addresses[5], "001172636", "Law", DateTime.Now, enrollments[5]),
                new Student("Kyron", "kyron@email.com", "0987654321", addresses[6], "001172637", "Journalism", DateTime.Now, enrollments[6]),
                new Student("Javier", "javier@email.com", "0987654321", addresses[7], "001172638", "Information Technology", DateTime.Now, enrollments[7]),
                new Student("Kyzo", "kyzo@email.com", "0987654321", addresses[8], "001172639", "Aeronautics", DateTime.Now, enrollments[8]),
                new Student("Ron", "ron@email.com", "0987654321", addresses[9], "001172630", "Computer Science", DateTime.Now, enrollments[9]),
            };

            Console.WriteLine($"Number of students: {students.Length}");

            Console.WriteLine();

            Console.WriteLine("Bubble Sort Descending: Results");
            Utility.BubbleSortDescending(students, (s1, s2) => s1.Name.CompareTo(s2.Name));
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].Name);
            }

            Console.WriteLine();
            Console.WriteLine("Bubble Sort Ascending: Results");
            Utility.BubbleSortAscending(students, (s1, s2) => s1.Name.CompareTo(s2.Name));

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].Name);
            }

            Console.WriteLine($"Testing Binary Search Method for Debugging:");

            // Example arrays (For Debugging)

            int[] sortedArray = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };


            // Example target value to search for
            int target = 11;

            // Call the BinarySearchArray method with the array and target value
            int resultIndex = Utility.BinarySearchArray(sortedArray, target);

            // Output the result
            if (resultIndex != -1)
            {
                Console.WriteLine($"The target value {target} was found at index {resultIndex}.");
            }
            else
            {
                Console.WriteLine($"The target value {target} was not found in the array.");
            }

            Console.ReadLine();
        }



        }
    }
