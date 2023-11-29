﻿
using MyProject.Models.realstates;
using MyProject.Services.PaymentPlanServices;
using MyProject1.Models.RealStates;
using System.Text.Json.Serialization;

namespace MyProject.Models.RealStates
{
    public class Compound
    {
        public int Id { get; set; }      
        public string Name { get; set; }
        public string Description { get; set; }
    
        public string Goverment { get; set; }
        public string Area { get; set; }
        public int DeveloperId { get; set; }  
        public string MasterPlanURL { get; set; }

        [JsonIgnore]
        public Developer Developer { get; set; }
        [JsonIgnore]
        public ICollection<RealEState> ReaEState { get; set; }
        [JsonIgnore]
        public ICollection<PaymentPlanForCompound>? paymentPlans { get; set; }
       
        public ICollection<CompoundAmenities> CompoundAmenities { get; set; }






    }
}
