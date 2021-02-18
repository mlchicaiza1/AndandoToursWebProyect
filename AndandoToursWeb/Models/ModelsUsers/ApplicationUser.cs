using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AndandoToursWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String FistName  { get; set; }

        public String LastName { get; set; }

    }
}
