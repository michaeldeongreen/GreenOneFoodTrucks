﻿using System;

namespace GreenOneFoodTrucks.Domain
{
    public class FoodTruck
    {
        public int ObjectId { get; set; }
        public string Applicant { get; set; }
        public string FacilityType { get; set; }
        public string CNN { get; set; }
        public string LocationDescription { get; set; }
        public string Address { get; set; }
        public string Blocklot { get; set; }
        public string Block { get; set; }
        public string Lot { get; set; }
        public string Permit { get; set; }
        public string Status { get; set; }
        public string FoodItems { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Schedule { get; set; }
        public string DaysHours { get; set; }
        public DateTime Noisent { get; set; }
        public DateTime Approved { get; set; }
        public string Received { get; set; }
        public string PriorPermit { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string LocationCity { get; set; }
        public string Point { get; set; }
        public string LocationAddress { get; set; }
        public string LocationZip { get; set; }
        public string LocationState { get; set; }
    }
}
