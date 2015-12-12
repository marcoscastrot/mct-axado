using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteAxado.Models
{
    [Table("UserCarrier")]
    public class UserCarrier
    {
        [Key, Column(Order = 0)]
        public int IdUser { get; set; }
        [Key, Column(Order = 1)]
        public int IdCarrier { get; set; }
        [Required]
        public int Rate { get; set; }
    }
}