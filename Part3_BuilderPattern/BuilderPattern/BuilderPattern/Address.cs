using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }
        public string Country { get; }

        

        private Address(string street, string city, string state, string zipCode, string country)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }

        public class Builder
        {
            private string street;
            private string city;
            private string state;
            private string zipCode;
            private string country;

            public Builder SetStreet(string street)
            {
                this.street = street;
                return this;
            }
            public Builder SetCity(string city)
            {
                this.city = city;
                return this;
            }
            public Builder SetState(string state)
            {
                this.state = state;
                return this;
            }
            public Builder SetZipCode(string zipCode)
            {
                this.zipCode = zipCode;
                return this;
            }
            public Builder SetCountry(string country)
            {
                this.country = country;
                return this;
            }
            public Address Build()
            {
                return new Address(street, city, state, zipCode, country);
                    
            }

        }
    }
}
