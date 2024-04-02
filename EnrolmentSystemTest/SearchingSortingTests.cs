
using EnrolmentSystem;

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

            students = new Student[]
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

            string[] studentNames = { "Kyron", "Kyle", "Javier", "Ian", "Ivan", "Carlo", "Heidi", "Reyka", "Shayne", "Angelica" };

            for (int i = 0; i < students.Length; i++)
            {
                students[i].Name = studentNames[i];
            }
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
            Student studentNotFound = new Student("001172640", "Engineering", DateTime.Now, new Enrollment(DateTime.Now, "FA", "Semester 1"));
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
            Student studentNotFound = new Student("001172640", "Engineering", DateTime.Now, new Enrollment(DateTime.Now, "FA", "Semester 1"));
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
