using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{

    [Table("addresses")]
    public class Address
    {


        // Properties
        [Key]
        public ulong Id { get; set; }

        [Column("type_of_address")]
        public string TypeOfAddress { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("entity")]
        public string Entity { get; set; }

        [Column("number_and_street")]
        public string NumberAndStreet { get; set; }

        [Column("suite_or_apartment")]
        public string SuiteOrApt { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("postal_code")]
        public string PostalCode { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }

    }
}

