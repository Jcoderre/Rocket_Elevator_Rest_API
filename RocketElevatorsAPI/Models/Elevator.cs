using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{
    [Table("elevators")]
    public class Elevator
    {

        // Fields
        private string status;


        // Properties
        [Key]
        public ulong Id { get; set; }

        [ForeignKey("column_id")]
        public ulong Column_Id { get; set; }

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
                    throw new System.Exception("Status given for elevator with ID " + this.Id + " is invalid. Please change it.");
                }
                status = value;
            }
        }

        [Column("serial_number")]
        public string SerialNumber { get; set; }

        [Column("model")]
        public string Model { get; set; }

        [Column("type_of_building")]
        public string BuildingType { get; set; }

        [Column("commissioning_date")]
        public DateTime CommissioningDate { get; set; }

        [Column("last_inspection_date")]
        public DateTime LastInspectionDate{ get; set; }

        [Column("inspection_certificate")]
        public string InspectionCertificate { get; set; }

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