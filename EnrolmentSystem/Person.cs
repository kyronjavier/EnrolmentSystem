using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrolmentSystem
{
    internal class Person
    {
        public const string DEF_NAME = "None Provided";
        public const string DEF_EMAIL = "unknown@example.com";
        public const string DEF_PHONE_NUMBER = "N/A";

        public static Address DEF_ADDRESS = new Address("123", "Main Street", "City", "1234", "SA");

        //private string name;
        //private string email;
        //private string phoneNumber;
        //private Address address;

        public static string Name { get; set; }
        public static string Email { get; set; }
        public static string PhoneNumber { get; set; }
        public Address Address { get; set; }

        public Person(): this(DEF_NAME, DEF_EMAIL, DEF_PHONE_NUMBER, DEF_ADDRESS) { }

        public Person(string name, string email, string phoneNumber, Address address)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public override string ToString()
        {
            return $"Name: {Name} \nEmail: {Email} \nPhone: {PhoneNumber} \nAddress: {Address}";
        }
    }
}
