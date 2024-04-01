using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EnrolmentSystem
{
    public class Address
    {
        public const string DEF_STREET_NUM = "None Provided";
        public const string DEF_STREET_NAME = "None Provided";
        public const string DEF_SUBURB = "None Provided";
        public const string DEF_POSTCODE = "None Provided";
        public const string DEF_STATE = "None Provided"; 
        
        //private string streetNum;
        //private string streetName;
        //private string suburb;
        //private string postcode;
        //private string state;

        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }

        public Address(): this(DEF_STREET_NUM, DEF_STREET_NAME, DEF_SUBURB, DEF_POSTCODE, DEF_STATE) { }

        public Address(string streetNum, string streetName, string suburb, string postcode, string state)
        {
            StreetNumber = streetNum;
            StreetName = streetName;
            Suburb = suburb;
            Postcode = postcode;
            State = state;
        }

        public override string ToString()
        {
            return $"{StreetNumber} {StreetName} {Suburb} {State} {Postcode} \n";
        }
    }
}
