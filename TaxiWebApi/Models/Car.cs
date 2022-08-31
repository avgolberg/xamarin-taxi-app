using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiWebApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public string CarColor { get; set; }
        public string RegistrationCertificate { get; set; }
        public string CarInsurance { get; set; }
        public Driver Driver { get; set; }
    }
}
