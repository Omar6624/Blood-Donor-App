using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blood_Donor_App_v4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Blood_Donor_App_v4.Data
{
    public class Blood_Donor_App_v4Context : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public Blood_Donor_App_v4Context (DbContextOptions<Blood_Donor_App_v4Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           /* builder.ApplyConfiguration(new DonorOtherInfoEntityConfiguration());*/
        }

        public DbSet<Blood_Donor_App_v4.Models.Donor> Donor { get; set; } = default!;
        /*public DbSet<Blood_Donor_App_v4.Models.DonorInfo> DonorInfo { get; set; }=default!;*/
        public DbSet<Blood_Donor_App_v4.Models.DonorOtherInfo> DonorOtherInfo { get; set; } = default!;
    }

  /* public class DonorOtherInfoEntityConfiguration : IEntityTypeConfiguration<DonorOtherInfo>
    {
        public void Configure(EntityTypeBuilder<DonorOtherInfo> builder)
        {
            builder.Property(u => u.Name).HasMaxLength(220);
            builder.Property(u => u.Address).HasMaxLength(220);
            builder.Property(u => u.Gender).HasMaxLength(220); 
            builder.Property(u => u.BloodType).HasMaxLength(220);
            throw new NotImplementedException();
        }
    }*/
}
