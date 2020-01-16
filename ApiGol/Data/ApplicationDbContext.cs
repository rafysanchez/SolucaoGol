using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGol.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiGol.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<AirplaneModel> Airplanes { get; set; }
    }

   


}
