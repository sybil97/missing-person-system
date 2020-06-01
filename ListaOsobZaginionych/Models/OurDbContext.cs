using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ListaOsobZaginionych.Models
{
    public class OurDbContext : DbContext
    {
        public OurDbContext() : base("DBCS") { }

        public DbSet<UserAccount> Users { get; set; }
        public DbSet<OsobaZaginiona> Zaginieci { get; set; }
    }
}