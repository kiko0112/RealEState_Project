using MyProject.Models.RealStates;
using System.Text.Json.Serialization;

namespace MyProject1.Models.RealStates
{
    public class CompoundAmenities
    {
      

        public Amenitiees? Amenities { get; set; }

        public int AmenitiesId { get; set; }

        public Compound  Compound { get; set; }
       public int CompoundId { get; set; }
    }
}
