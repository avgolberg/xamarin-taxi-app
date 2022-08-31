using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Rider Rider { get; set; }
        public DateTime StartTime { get; set; }
        public string StartLocation { get; set; }//
        public string EndLocation { get; set; } //
        public PaymentMethod PaymentMethod { get; set; }
        public Driver Driver { get; set; }
        public DateTime EndTime { get; set; }
        public int Price { get; set; }
        public Dispatcher Dispatcher { get; set; }
        public Status Status { get; set; }
        public int Rating { get; set; }
        public string Feedback { get; set; }
    }
}
