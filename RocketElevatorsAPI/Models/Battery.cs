using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models 
{

    [Table("batteries")]
    public class Battery
    {

        // Fields
        private string status; 

        // Properties
        [Key]
        public ulong Id { get; set; }

        [ForeignKey("building_id")]
        public string Building_Id { get; set; }

        [ForeignKey("employee_id")]
        public string Employee_Id { get; set; }

        [ForeignKey("customer_id")]
        public ulong Customer_Id { get; set; }


        [Column("status")]
        public string Status 
        {
            get { return status; }
            set 
            {
                if (value.ToLower() != "active" && value.ToLower() != "inactive" && value.ToLower() != "intervention")
                {
                    throw new System.Exception("Status given for battery with ID " + this.Id + " is invalid. Please change it.");
                }
                status = value;
            }
        }

        [Column("commissioning_date")]
        public DateTime CommissioningDate { get; set; }

        [Column("last_inspection_date")]
        public DateTime LastInspectionDate{ get; set; }

        [Column("operations_certificate")]
        public string OperationsCertificate { get; set; }

        [Column("information")]
        public string Information { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}