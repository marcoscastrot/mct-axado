namespace TesteAxado.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TesteAxado.Models;

    public sealed class Configuration : DbMigrationsConfiguration<TesteAxado.Context.TesteAxadoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TesteAxado.Context.TesteAxadoContext context)
        {
            var users = new List<User>
            {
                new User { Login = "admin" },
                new User { Login = "user" },
                new User { Login = "marcoscastrotinos" }
            };
            users.ForEach(s => context.Users.AddOrUpdate(p => p.Login, s));
            context.SaveChanges();
        }

        public void ExecuteSeed(TesteAxado.Context.TesteAxadoContext context)
        {
            Seed(context);
        }
    }
}
