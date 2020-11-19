using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{

    [Table("quotes")]
    public class Quote
    {

        
        // Properties
        [Key]
        public ulong Id { get; set; }

        [Column("building_type")]
        public string Building_Type { get; set; }

        [Column("no_of_appartments")]
        public int NumAppartments { get; set; }

        [Column("no_of_floors")]
        public int NumFloors { get; set; }

        [Column("no_of_basements")]
        public int NumBasements { get; set; }

        [Column("no_of_elevators_cages")]
        public int NumElevatorCages { get; set; }

        [Column("no_of_parking_spaces")]
        public int NumParkingSpaces { get; set; }

        [Column("no_of_tenant_companies")]
        public int NumTenantCompanies { get; set; }

        [Column("no_of_distinct_businesses")]
        public int NumDistinctBusiness { get; set; }

        [Column("max_occupants_per_floors")]
        public int MaxOccPerFloor { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("no_of_elevators")]
        public int NumElevators { get; set; }

        [Column("product_grade")]
        public string ProductGrade { get; set; }

        [Column("elevator_cost")]
        public string ElevatorCost { get; set; }    

        [Column("installation_cost")]
        public string InstallationCost { get; set; }   

        [Column("total_cost")]
        public string TotalCost { get; set; }  

        [Column("no_of_daily_hours_of_activity")]
        public int DailyHoursActivity { get; set; }  

        [Column("company_name")]
        public string CompanyName { get; set; }

        [Column("contact_email")]
        public string ContactEmail { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

    }
}