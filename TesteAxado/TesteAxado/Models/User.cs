using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteAxado.Models
{
    [Table("User")]
    public class User : BaseModel
    {
        [Required]
        [MaxLength(500)] 
        [DisplayName("Login")]
        public string Login { get; set; }
    }
}