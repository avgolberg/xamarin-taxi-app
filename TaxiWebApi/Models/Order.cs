using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiWebApi.Models
{
    public enum PaymentMethod
    {
        Cash, Card
    }

    public enum Status
    {
        New, OrderForTime, Cancelled,
        CarSearching, Booked, NoСarAvailable,
        CarDrivesToClient, DriverArrived, Driving, Driven,
        PaymentByCard, PaymentByCash, PaymentDone,
        Done, Problem
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public City City { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public CarType CarType { get; set; }
        public List<Parameter> Parameters { get; set; }
        public Status Status { get; set; }

        public Rider Rider { get; set; }
        public Driver Driver { get; set; }
        public Administrator Administrator { get; set; }

        public DateTime EndTime { get; set; }
        // public double Distance { get; set; } //km
        public int Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int Rating { get; set; }
        public string Feedback { get; set; }
    }
}
