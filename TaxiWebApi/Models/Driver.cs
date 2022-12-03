using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiWebApi.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBrith { get; set; }
        public City City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string DriverLicense { get; set; }
        public List<DriverOption> DriverOptions { get; set; }
        public string IBAN { get; set; }
        public string PasswordHash { get; set; }

        public bool IsOnline { get; set; }
    }
}
