using System;

namespace TravelCRMEntities
{
    public class Leads
    {

        public string DepapartureCity { get; set; }
        public string DestinationCity { get; set; }
        public int PaxNumber { get; set; }
        public int HotelRating { get; set; }
        public TravelMode ModeOfTravel { get; set; }
        public string StayPeriod { get; set; }
        public Customer CustomerDetail { get; set; }
        public LeadStatus CurrentStatus { get; set; }

    }


    public enum TravelMode
    {
        ByAir,
        ByTrain

    }

    public enum LeadStatus
    {
        None,
        TeamLead,
        Employee,
        Operation

    }

    public class Customer
    {

        public string CustomerID { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public int MobileNUmber { get; set; }

        

    }
}
