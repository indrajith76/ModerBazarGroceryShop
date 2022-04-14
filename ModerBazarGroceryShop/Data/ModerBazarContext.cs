using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Data
{
    public class ModerBazarContext : DbContext
    {
        public ModerBazarContext(DbContextOptions<ModerBazarContext> options)
            : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }

    }
}
