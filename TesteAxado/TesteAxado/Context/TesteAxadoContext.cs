using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TesteAxado.Migrations;
using TesteAxado.Models;

namespace TesteAxado.Context
{
    public class TesteAxadoContext : DbContext
    {
        public TesteAxadoContext()
            : base("TesteAxadoContext")
        {
        }
        
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCarrier> UsersCarriers { get; set; }
    }
}
