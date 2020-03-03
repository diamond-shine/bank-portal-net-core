using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public struct Address
    {
        public string Street;
        public string City;
        public string Province;
        public string PostalCode;

        public Address(string street = "", string city = "", string province = "", string postalCode = "")
        {
            Street = street;
            City = city;
            Province = province;
            PostalCode = postalCode;
        }
    }
}
