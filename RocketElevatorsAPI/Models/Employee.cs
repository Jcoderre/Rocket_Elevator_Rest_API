using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{

    [Table("employees")]
    public class Employee
    {
        // Properties
        
        [Key]
        public ulong Id { get; set; }

        [Column("first_name")]
        public string firstName { get; set; }

        [Column("last_name")]
        public string lastName { get; set; }

        [Column("title")]
        public string employeeTitle { get; set; }

        [Column("email")]
        public string employeeEmail { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("admin_user_id")]
        public ulong adminUserId { get; set; }

        [Column("phone_number")]
        public string phoneNumber { get; set; }
    }
}