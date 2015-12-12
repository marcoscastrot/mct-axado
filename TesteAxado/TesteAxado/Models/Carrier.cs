using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteAxado.Models
{
    [Table("Carrier")]
    public class Carrier : BaseModel
    {
        [Required]
        [MaxLength(500)] 
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Identification number")]
        public string Identifier { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Phone number")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(250)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Number")]
        public int? Number { get; set; }

        [MaxLength(9)]
        [DisplayName("Postal code")]
        public string PostalCode { get; set; }
    }
}