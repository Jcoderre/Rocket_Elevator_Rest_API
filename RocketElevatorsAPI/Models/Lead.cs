using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{
    [Table("leads")]
    public class Lead
    {

        // Properties
        [Key]
        public ulong Id { get; set; }

        /*
        [ForeignKey("customer_id")]
        public ulong Customer_Id { get; set; }
        */

        [Column("contact_full_name")]
        public string ContactName { get; set; }

        [Column("company_name")]
        public string CompanyName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("project_name")]
        public string ProjectName { get; set; }

        [Column("project_description")]
        public string ProjectDescription { get; set; }

        [Column("department")]
        public string Department { get; set; }

        [Column("message")]
        public string Message { get; set; }

        /*
        [Column("attached_file")]
        public byte? AttachedFile { get; set; }
        */

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}


