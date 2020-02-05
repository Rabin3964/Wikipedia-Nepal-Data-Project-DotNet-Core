using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WikiDataNepal.Models
{
    public class NepalDataContextMain : DbContext
    {
        public NepalDataContextMain(DbContextOptions<NepalDataContextMain> options) : base(options)
        {

        }

        public DbSet<NepalDataContextMain> Test { get; set; }
    }
}
