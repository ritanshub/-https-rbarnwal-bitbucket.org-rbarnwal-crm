﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCRM.Models;

namespace TravelCRM.Areas.Employee.Model
{
    public class LeadViewModel
    {
        public int LeadID { get; set; }
        public string LeadSource { get; set; }
        public DateTime? ModifiedTime { get; set; }

        public string JourneySource { get; set; }
        public string JourneyDestination { get; set; }

        public double Budget { get; set; }

        public string LeadStatus { get; set; }

        public string ModeOfTravel { get; set; }

        //public int PaxNumber { get; set; }
        //public int HotelRating { get; set; }


        public string StayPeriod { get; set; }

        public GridAction EditAction { get; set; }
    }
    //public class UserNotification
    //{
    //    public string Title { get; set; }
    //    public string Details { get; set; }
    //    public string Date { get; set; }
    //}
}
