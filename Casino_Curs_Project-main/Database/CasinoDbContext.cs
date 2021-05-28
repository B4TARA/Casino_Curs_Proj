using Casino_Schmirtz_Royale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Casino_Schmirtz_Royale.Database
{
    public class CasinoDbContext : DbContext
    {
        public CasinoDbContext() : base("DBConnection") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<SpinHistory> Spin { get; set; }
        public DbSet<TopUpHistory> TopUp { get; set; }



    }
}
