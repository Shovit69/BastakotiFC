using ShovitBastakoti.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ShovitBastakoti.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {

   
      

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
