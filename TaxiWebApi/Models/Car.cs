using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiWebApi.Models
{
    public enum CarType
    {
        Standard, Business, Truck, Minivan
    }
    public class Car
    {
        public int Id { get; set; }
        public Driver Driver { get; set; }
        public CarType CarType { get; set; }
        
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public string CarColor { get; set; }
        public string RegistrationCertificate { get; set; }
        public bool IsUkrRegistration { get; set; }
        public string CarInsurance { get; set; }
        public bool HasAirConditioner { get; set; }
        public bool HasSeatBeltsBehind { get; set; }
       
    }
}
