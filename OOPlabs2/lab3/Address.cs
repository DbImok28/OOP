using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    [Serializable]
    public class Address
    {
        public Address()
        {

        }
        public Address(string country, string city, string district, string street, 
                       string house, string building, string apartmentNumber)
        {
            index = -1;
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
            return $"{City}, р.{District}, ул.{Street}, д.{Building}, к.{ApartmentNumber}";
        }
        [Index]
        public int index { get; set; } = -1;
        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от {2} до {1} символов")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Страна не указана")]
        public string Country { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Город не указан")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Район не указан")]
        public string District { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Улица не указана")]
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Номер дома не указан")]
        public string House { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Корпус не указан")]
        public string Building { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Номер квартиры не указан")]
        [RegularExpression(@"(\d*\w?)", ErrorMessage = "Номер квартиры указан не верно")]
        public string ApartmentNumber { get; set; }
    }
}
