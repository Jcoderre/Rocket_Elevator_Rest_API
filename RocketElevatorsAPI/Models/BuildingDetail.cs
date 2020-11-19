using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{

    [Table("building_details")]
    public class BuildingDetail
    {

        // Properties
        
        [Key]
        public ulong Id { get; set; }

        [Column("information_key")]
        public string InfoKey { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("building_id")]
        public ulong Building_Id { get; set; }

        [ForeignKey("customer_id")]
        public ulong Customer_Id { get; set; }

    }
}