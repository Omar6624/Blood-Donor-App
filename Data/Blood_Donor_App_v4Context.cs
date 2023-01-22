using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blood_Donor_App_v4.Models;

namespace Blood_Donor_App_v4.Data
{
    public class Blood_Donor_App_v4Context : DbContext
    {
        public Blood_Donor_App_v4Context (DbContextOptions<Blood_Donor_App_v4Context> options)
            : base(options)
        {
        }

        public DbSet<Blood_Donor_App_v4.Models.Donor> Donor { get; set; } = default!;
    }
}
