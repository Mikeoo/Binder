using System;
namespace Binder.Models
{
    public class HouseProfile
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public bool IsRent { get; set; }
        public int HouseNumber { get; set; }
        public string HouseNumberAddition { get; set; }
        public double Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Photo { get; set; }
        public HouseTypes HouseType { get; set; }
    }
}
