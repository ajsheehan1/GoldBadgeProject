﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    public enum ClaimType { Car = 1
            , Home, Theft }
    
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }

        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public  bool IsValid {
            get
            {
                TimeSpan claimSpan = DateOfClaim - DateOfIncident;
                double totalDays = claimSpan.TotalDays;
                if(totalDays <= 30)
                {
                    return true;
                }
                else { return false; }
            }
        }

        public Claim()
        {

        }

        public Claim(int claimID, ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        } 
 
}


}
