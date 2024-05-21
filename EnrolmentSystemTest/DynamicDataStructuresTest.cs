using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrolmentSystemTest
{
    internal class DynamicDataStructuresTest
    {
        // Testings for the Single Linked list
        [TestFixture]
        public class SingleLinkedListTests
        {
            private SingleLinkedList<Student> list;

            [SetUp]
            public void Setup()
            {
                list = new SingleLinkedList<Student>();
            }

            [Test]
            public void AddToHeadTest()
            {
                var student = new Student("Test Student", "test@student.com", "1234567890", new Address(), "1001", "Test Course", DateTime.Now, new Enrollment());
                list.AddFirst(student);
                var head = list.Head.Value;
                Assert.AreEqual(student, head);
            }

            [Test]
            public void AddToTailTest()
            {
                var student = new Student("Test Student", "test@student.com", "1234567890", new Address(), "1001", "Test Course", DateTime.Now, new Enrollment());
                list.AddLast(student);
                var tail = list.Tail.Value;
                Assert.AreEqual(student, tail);
            }

            [Test]
            public void FindNodeTest()
            {
                var student = new Student("Test Student", "test@student.com", "1234567890", new Address(), "1001", "Test Course", DateTime.Now, new Enrollment());
                list.AddLast(student);
                var found = list.Find(student);
                Assert.IsNotNull(found);
                Assert.AreEqual(student, found.Value);
            }

            [Test]
            public void RemoveFromHeadTest()
            {
                var student = new Student("Test Student", "test@student.com", "1234567890", new Address(), "1001", "Test Course", DateTime.Now, new Enrollment());
                list.AddFirst(student);
                var removed = list.RemoveFirst();
                Assert.AreEqual(student, removed);
                Assert.IsNull(list.Head);
            }

            [Test]
            public void RemoveFromTailTest()
            {
                var student = new Student("Test Student", "test@student.com", "1234567890", new Address(), "1001", "Test Course", DateTime.Now, new Enrollment());
                list.AddLast(student);
                var removed = list.RemoveLast();
                Assert.AreEqual(student, removed);
                Assert.IsNull(list.Tail);
            }

        }


        // Testings for the Double Linked List
        [TestFixture]
        public class DoublyLinkedListTests
        {
            private DoublyLinkedList<Student> list;
            [SetUp]
            public void SetUp()
            {
                list = new DoublyLinkedList<Student>();
            }
            [Test]
            public void AddToHeadTest()
            {
                var student = new Student("Test Student", "test@student.com", "1234567890", new Address(), "1001", "Test Course", DateTime.Now, new Enrollment());
                list.AddFirst(student);
                var head = list.Head.Value;
                Assert.AreEqual(student, head);
            }

            [Test]
            public void AddToTailTest()
            {
                var student = new Student("Test Student", "test@student.com", "1234567890", new Address(), "1001", "Test Course", DateTime.Now, new Enrollment());
                list.AddLast(student);
                var tail = list.Tail.Value;
                Assert.AreEqual(student, tail);
            }

            [Test]
            public void FindNodeTest()
            {
                var student = new Student("Test Student", "test@student.com", "1234567890", new Address(), "1001", "Test Course", DateTime.Now, new Enrollment());
                list.AddLast(student);
                var found = list.Find(student);
                Assert.IsNotNull(found);
                Assert.AreEqual(student, found.Value);
            }

            [Test]
            public void RemoveFromHeadTest()
            {
                var student = new Student("Test Student", "test@student.com", "1234567890", new Address(), "1001", "Test Course", DateTime.Now, new Enrollment());
                list.AddFirst(student);
                var removed = list.RemoveFirst();
                Assert.AreEqual(student, removed);
                Assert.IsNull(list.Head);
            }

            [Test]
            public void RemoveFromTailTest()
            {
                var student = new Student("Test Student", "test@student.com", "1234567890", new Address(), "1001", "Test Course", DateTime.Now, new Enrollment());
                list.AddLast(student);
                var removed = list.RemoveLast();
                Assert.AreEqual(student, removed);
                Assert.IsNull(list.Tail);
            }
        }
        [TestFixture]
        public class BinaryTreeTests
        {
            private BinaryTree<Student> bst;


            Enrollment[] enrollments = new Enrollment[]
            {
                new Enrollment(DateTime.Now, "PA", "Semester 1"),
                new Enrollment(DateTime.Now, "FA", "Semester 3"),
                new Enrollment(DateTime.Now, "PA", "Semester 2"),
                new Enrollment(DateTime.Now, "PA", "Semester 2"),
                new Enrollment(DateTime.Now, "PA", "Semester 2"),
                new Enrollment(DateTime.Now, "FA", "Semester 3"),
                new Enrollment(DateTime.Now, "PA", "Semester 1"),
            };

            Address[] addresses = new Address[]
            {
                new Address("123", "Street1", "Suburb1", "1234", "SA"),
                new Address("234", "Street2", "Suburb2", "2345", "SA"),
                new Address("345", "Street3", "Suburb3", "3456", "SA"),
                new Address("456", "Street4", "Suburb4", "4567", "SA"),
                new Address("567", "Street5", "Suburb5", "5678", "SA"),
                new Address("789", "Street6", "Suburb6", "6789", "SA"),
                new Address("890", "Street7", "Suburb7", "7890", "SA")
            };

            [SetUp]
            public void SetUp()
            {
                bst = new BinaryTree<Student>();
            }

            [Test]
            public void InOrderTraversalTest()
            {
                AddStudentsToTree();
                List<string> result = new List<string>();
                bst.InOrderTraversal(student => result.Add(student.StudentID));

                string[] expected = { "001172631", "001172632", "001172633", "001172634", "001172635", "001172636", "001172637" };
                CollectionAssert.AreEqual(expected, result);
            }

            [Test]
            public void PreOrderTraversalTest()
            {
                AddStudentsToTree();
                List<string> result = new List<string>();
                bst.PreOrderTraversal(student => result.Add(student.StudentID));

                string[] expected = { "001172634", "001172632", "001172631", "001172633", "001172636", "001172635", "001172637" };
                CollectionAssert.AreEqual(expected, result);
            }

            [Test]
            public void PostOrderTraversalTest()
            {
                AddStudentsToTree();
                List<string> result = new List<string>();
                bst.PostOrderTraversal(student => result.Add(student.StudentID));

                string[] expected = { "001172631", "001172633", "001172632", "001172635", "001172637", "001172636", "001172634" };
                CollectionAssert.AreEqual(expected, result);
            }

            private void AddStudentsToTree()
            {
                Student[] students = new Student[]
                {
            new Student("Kyle", "kyle@email.com", "0987654321", addresses[0], "001172634", "Computer Science", DateTime.Now, enrollments[0]),
            new Student("Aaron", "aaron@email.com", "0987654321", addresses[1], "001172632", "Computer Engineering", DateTime.Now, enrollments[1]),
            new Student("Angelica", "angelica@email.com", "0987654321", addresses[2], "001172631", "Medical Science", DateTime.Now, enrollments[2]),
            new Student("Xavier", "xavier@email.com", "0987654321", addresses[3], "001172633", "Hospitality Management", DateTime.Now, enrollments[3]),
            new Student("Maria", "maria@email.com", "0987654321", addresses[4], "001172636", "Mechanical Engineering", DateTime.Now, enrollments[4]),
            new Student("Jericho", "jericho@email.com", "0987654321", addresses[5], "001172635", "Law", DateTime.Now, enrollments[5]),
            new Student("Kyron", "kyron@email.com", "0987654321", addresses[6], "001172637", "Journalism", DateTime.Now, enrollments[6])
                };

                foreach (var student in students)
                {
                    bst.Add(student);
                }
            }
        }

    }
    }

