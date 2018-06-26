using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TravelCRMEntities
{
    public class Lead: BaseEntities
    {
        [Key]
        public int LeadID { get; set; }
        public string LeadSource { get; set; }
        public DateTime? ModifiedTime { get; set; }

        public string JourneySource { get; set; }
        public string JourneyDestination { get; set; }

        public double Budget { get; set;}

        public LeadStatus CurrentStatus { get; set; }

        public TravelMode ModeOfTravel { get; set; }
       
        //public int PaxNumber { get; set; }
        //public int HotelRating { get; set; }

        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        public string StayPeriod { get; set; }
        

        public ICollection<LeadEmployeeMapper> LeadEmployeeMapper { get; set; }

    }

    public class Team : BaseEntities
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ManagerName { get; set; }
        public int ManagerID { get; set; }
    }

    public class Employee:BaseEntities
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public int MobileNUmber { get; set; }
       
        public DateTime DOB { get; set; }
        public int Active { get; set; }

        public int RoleID { get; set; }
        public Role Role { get; set; }


        public ICollection<LeadEmployeeMapper> LeadEmployeeMapper { get; set; }


        public ICollection<CustomerEnquiryDetails> CustomerEnquiryDetails { get; set; }
    }


    public class LeadEmployeeMapper:BaseEntities
    {

        public int LeadEmployeeMapperID { get; set; }

        public int LeadID { get; set; }

       
        public int EmployeeID { get; set; }

        public Employee employee { get; set; }

        public Lead lead { get; set; }

        public int Level{ get; set; }
    }


    public class CustomerEnquiryDetails
    {
        public int EnquiryID { get; set; }
        
        public int CustomerID { get; set; }
        
        public int EmployeeID { get; set; }

        
        public int LeadID { get; set; }

        public string Loaction { get; set; }
        public string TravelSource { get; set; }
        public string TravelDestination { get; set; }
        public string TraveCategory { get; set; }
        public string AccomdationCategory { get; set; }

        public string TourCategory { get; set; }
        public DateTime? TravelExpectedDate { get; set; }
        public double Budget { get; set; }
        public LeadStatus Status { get; set; }


        public Lead lead { get; set; }

        public Customer Customer { get; set; }


        public Employee employee { get; set; }

    }


    public class Customer : BaseEntities
    {

        public string CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public int MobileNUmber { get; set; }

        public ICollection<CustomerEnquiryDetails> CustomerEnquiryDetails { get; set; }

    }



    public class EnquiryTranscation
    {
        public int EnquiryTranscationID { get; set; }

        public int EnquiryID { get; set; }
        
        public int QuotationID { get; set; }
        
       
        public string EmployeeComment { get; set; }
        public string BackendComment { get; set; }
        public string ActionTobeTaken { get; set; }
        public string PendingWith { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string TourCategory { get; set; }
        public DateTime? NextFollowUpDate { get; set; }
        public string ModiFiedBy { get; set; }

    }

    public class Role : BaseEntities
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int Active { get; set; }

    }

    public class PermissionDetails
    {



        public int RoleID { get; set; }

        public string ControllerName { get; set; }
        
        public string ActionName { get; set; }

        public string PermissionSet { get; set; }

        public Role Role { get; set; }

    }

    public class ApplicationUser 
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsLoggedIn { get; set; }

        public string SecretCode { get; set; }

        [ForeignKey("EmployeeID")]
        public string EmployeeID { get; set;}
        public Employee emp { get; set; }

        public int RoleID { get; set; }
        public Role role { get; set; }


    }


    public class SingnInResult
    {

        public bool Result { get; set; }
        public ApplicationUser AppUser { get; set; }
    }

    public enum Permissions
    {
        Read,
        ReadWrite,
        None
    }

    public class EmployeeManagerMapping
    {
        public int EmployeeID { get; set; }
        public int ManagerID { get; set; }
       
    }

   
    public enum TravelMode
    {
        ByAir,
        ByTrain

    }

    public enum LeadStatus
    {
        None,
        Assign,
        Inprogress,
        TeamLead,
        Employee,
        Operation

    }

}
