using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{

    [Table("buildings")]
    public class Building
    {
        // Properties
        
        [Key]
        public ulong Id { get; set; }

        [ForeignKey("customer_id")]
        public ulong Customer_Id { get; set; }

        [ForeignKey("address_id")]
        public ulong Address_Id { get; set; }

        [Column("email_of_the_administrator_of_the_building")]
        public string AdministratorEmail { get; set; }

        [Column("phone_number_of_the_building_administrator")]
        public string AdministratorPhone { get; set; }

        [Column("full_name_of_the_technical_contact_for_the_building")]
        public string TechnicalContactFullName { get; set; }

        [Column("technical_contact_email_for_the_building")]
        public string TechnicalContactEmail { get; set; }

        [Column("technical_contact_phone_for_the_building")]
        public string TechnicalContactPhone{ get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}