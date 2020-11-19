using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{
    [Table("columns")]
    public class Column
    {

        // Fields
        private string status; 

        // Properties

        [Key]
        public ulong Id { get; set; }

        [ForeignKey("battery_id")]
        public ulong Battery_Id { get; set; }

        [ForeignKey("customer_id")]
        public ulong Customer_Id { get; set; }

        [Column("type_of_building")]
        public string BuildingType { get; set; }

        [Column("number_of_floors_served")]
        public int NumFloors { get; set; }

        [Column("status")]
        public string Status 
        {
            get { return status; }
            set 
            {
                if (value.ToLower() != "active" && value.ToLower() != "inactive" && value.ToLower() != "intervention")
                {
                    throw new System.Exception("Status given for column with ID " + this.Id + " is invalid. Please change it.");
                }
                status = value;
            }
        }
        
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