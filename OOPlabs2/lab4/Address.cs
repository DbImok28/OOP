using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    [Serializable]
    public class Address : ICloneable
    {
        public Address()
        {

        }
        public Address(string country, string city, string district, string street, 
                       string house, string building, string apartmentNumber)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentException($"'{nameof(country)}' cannot be null or whitespace.", nameof(country));
            }
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException($"'{nameof(city)}' cannot be null or whitespace.", nameof(city));
            }
            if (string.IsNullOrWhiteSpace(district))
            {
                throw new ArgumentException($"'{nameof(district)}' cannot be null or whitespace.", nameof(district));
            }
            if (string.IsNullOrWhiteSpace(street))
            {
                throw new ArgumentException($"'{nameof(street)}' cannot be null or whitespace.", nameof(street));
            }
            if (string.IsNullOrWhiteSpace(house))
            {
                throw new ArgumentException($"'{nameof(house)}' cannot be null or whitespace.", nameof(house));
            }
            if (string.IsNullOrWhiteSpace(building))
            {
                throw new ArgumentException($"'{nameof(building)}' cannot be null or whitespace.", nameof(building));
            }
            if (string.IsNullOrWhiteSpace(apartmentNumber))
            {
                throw new ArgumentException($"'{nameof(apartmentNumber)}' cannot be null or whitespace.", nameof(apartmentNumber));
            }

            Country = country;
            City = city;
            District = district;
            Street = street;
            House = house;
            Building = building;
            ApartmentNumber = apartmentNumber;
        }
        public override string ToString()
        {
            return $"{City} ул.{Street}, д.{Building}, к.{ApartmentNumber}";
        }

        public object Clone()
        {
            return new Address(Country, City, District, Street, House, Building, ApartmentNumber);
        }

        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Building { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
