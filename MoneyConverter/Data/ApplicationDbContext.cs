using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MoneyConverter.Models;

namespace MoneyConverter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       

         //Database set objects for each model class
        public DbSet<Country>Countries { get; set; }
        public DbSet<CountryRate>CountryRates { get; set; }
        public DbSet<Result>Results { get; set; }
    }
}
