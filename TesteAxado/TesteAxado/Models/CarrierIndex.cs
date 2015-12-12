using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteAxado.Models
{
    public class CarrierIndex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public float AverageRate { get; set; }
    }
}