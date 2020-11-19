using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{

    [Table("interventions")]
    public class Intervention
    {


        // Properties
        [Key]
        public ulong Id { get; set; }

        [Column("intervention_start")]
        public DateTime InterventionStart { get; set; }

        [Column("intervention_stop")]
        public DateTime InterventionStop { get; set; }

        [Column("result")]
        public string Result { get; set; }

        [Column("report")]
        public string Report { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("author")]
        public int Author { get; set; }

        [Column("customer_id")]
        public int Customer_id { get; set; }

        [Column("building_id")]
        public int Building_id { get; set; }

        [Column("column_id")]
        public int Column_id { get; set; }

        [Column("employee_id")]
        public int Employee_id { get; set; }

        [Column("battery_id")]
        public int Battery_id { get; set; }

        [ForeignKey("elevator_id")]
        public ulong Elevator_Id { get; set; }

    }
}