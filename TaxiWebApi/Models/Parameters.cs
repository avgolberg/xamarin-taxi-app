using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiWebApi.Models
{
    public enum ParameterId
    {
        AirConditioner, UseSeatBeltsBehind, UkrainianRegistration, EnglishSpeakingDriver,
        WithChildren, WithPets, SilentDriver, DoNotCall,
        Deaf, EmptyTrunk
    }
    public class Parameter
    {
        public ParameterId ParameterId { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }

}
