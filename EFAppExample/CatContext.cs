using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFAppExample
{
    /// <summary>
    /// Class which creates connecting structure to DB 
    /// </summary>
    public class CatContext : DbContext
    {
        public CatContext() : base("DbConnection") { }
        public DbSet<Cat> Cats { get; set; }
    }
}
