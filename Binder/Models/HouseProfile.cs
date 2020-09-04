using System;
namespace Binder.Models
{
    public class HouseProfile
    {
        public string Id { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public HouseTypes HouseType { get; set; }
    }
}
