using System;
using System.Collections.Generic;
using System.Text;
using AndandoToursWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AndandoToursWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AndandoToursWeb.Models.ProjectRole> ProjectRole { get; set; }

       
    }
}
