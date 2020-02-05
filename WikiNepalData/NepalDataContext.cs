using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WikiNepalData.Model;

namespace WikiNepalData
{
    public class NepalDataContext : DbContext
    {

        public NepalDataContext(DbContextOptions<NepalDataContext> options) : base(options)
        {

        }

        public DbSet<NepalDataModel> Test{ get; set; }

    }
}

