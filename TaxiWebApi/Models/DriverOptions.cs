using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiWebApi.Models
{
    public enum DriverOptionId
    {
        OrderForTime, DrivePassengerCar, DeliverParcel,
        TruckDriver,
        EnglishSpeaking
    }

    public class DriverOption
    {
        public DriverOptionId DriverOptionId { get; set; }
        public string Name { get; set; }
        public List<Driver> Drivers { get; set; }
    }
}
