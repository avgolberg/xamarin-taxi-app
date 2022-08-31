using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiWebApi.Models
{
    public class Rider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public City City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
    }
}
