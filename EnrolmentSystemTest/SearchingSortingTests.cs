
using System.Net.Sockets;

namespace EnrolmentTest
{
    [TestFixture]
    public class SearchingAndSortingTests
    {
        private Student[] students;

        [SetUp]
        public void Setup()
        {
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

            students = new Student[]
            {
                new Student("Kyle","kyle@email.com", "0987654321", addresses[0], "001172631", "Computer Science", DateTime.Now, enrollments[0]),
                new Student("Aaron","aaron@email.com", "0987654321", addresses[1],"001172632", "Computer Engineering", DateTime.Now, enrollments[1]),
                new Student("Angelica","angelica@email.com", "0987654321", addresses[2],"001172633", "Medical Science", DateTime.Now, enrollments[2]),
                new Student("Xavier","xavier@email.com", "0987654321", addresses[3],"001172634", "Hospitality Management", DateTime.Now, enrollments[3]),
                new Student("Maria","maria@email.com", "0987654321", addresses[4],"001172635", "Mechanical Engineering", DateTime.Now, enrollments[4]),
                new Student("Jericho","jericho@email.com", "0987654321", addresses[5],"001172636", "Law", DateTime.Now, enrollments[5]),
                new Student("Kyron","kyron@email.com", "0987654321", addresses[6],"001172637", "Journalism", DateTime.Now, enrollments[6]),
                new Student("Javier","javier@email.com", "0987654321", addresses[7],"001172638", "Information Technology", DateTime.Now, enrollments[7]),
                new Student("Kyzo","kyzo@email.com", "0987654321", addresses[8],"001172639", "Aeronautics", DateTime.Now, enrollments[8]),
                new Student("Ron","ron@email.com", "0987654321", addresses[9],"001172630", "Computer Science", DateTime.Now, enrollments[9]),
            };
        }

        [Test]
        public void TestLinearSearchArray_StudentFound()
        {
            int index = Utility.LinearSearchArray(students, students[3]);
            Assert.AreEqual(3, index);
        }

        [Test]
        public void TestLinearSearchArray_StudentNotFound()
        {
            Student studentNotFound = new Student("Jessica", "jessica@email.com", "0987654321", new Address(), "001172640", "Engineering", DateTime.Now, new Enrollment(DateTime.Now, "FA", "Semester 1"));
            int index = Utility.LinearSearchArray(students, studentNotFound);
            Assert.AreEqual(-1, index);
        }

        [Test]
        public void TestBinarySearchArray_StudentFound()
        {
            Array.Sort(students); // Ensure the array is sorted for binary search
            int index = Utility.BinarySearchArray(students, students[7]);
            Assert.AreEqual(7, index);
        }

        [Test]
        public void TestBinarySearchArray_StudentNotFound()
        {
            Array.Sort(students); // Ensure the array is sorted for binary search
            Student studentNotFound = new Student("Jessica", "jessica@email.com", "0987654321", new Address(), "001172640", "Engineering", DateTime.Now, new Enrollment(DateTime.Now, "FA", "Semester 1"));
            int index = Utility.BinarySearchArray(students, studentNotFound);
            Assert.AreEqual(-1, index);
        }

        [Test]
        public void TestBubbleSortAscending_StudentID()
        {
            Utility.BubbleSortAscending(students, (s1, s2) => s1.StudentID.CompareTo(s2.StudentID));
            Assert.AreEqual("001172630", students[0].StudentID); // Verify first element after sorting
            Assert.AreEqual("001172639", students[students.Length - 1].StudentID); // Verify last element after sorting
        }

        [Test]
        public void TestBubbleSortDescending_StudentID()
        {
            Utility.BubbleSortDescending(students, (s1, s2) => s1.StudentID.CompareTo(s2.StudentID));
            Assert.AreEqual("001172639", students[0].StudentID); // Verify first element after sorting
            Assert.AreEqual("001172630", students[students.Length - 1].StudentID); // Verify last element after sorting
        }

        [Test]
        public void TestBubbleSortAscending_Name()
        {
            Utility.BubbleSortAscending(students, (s1, s2) => s1.Name.CompareTo(s2.Name)); // Sort by Name
            Assert.AreEqual("Angelica", students[0].Name); // Verify first element after sorting
            Assert.AreEqual("Shayne", students[students.Length - 1].Name); // Verify last element after sorting
        }

        [Test]
        public void TestBubbleSortDescending_Name()
        {
            Utility.BubbleSortDescending(students, (s1, s2) => s1.Name.CompareTo(s2.Name));
            Assert.AreEqual("Shayne", students[0].Name); // Verify first element after sorting
            Assert.AreEqual("Angelica", students[students.Length - 1].Name); // Verify last element after sorting
        }
    }
}
