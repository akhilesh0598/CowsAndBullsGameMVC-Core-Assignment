using CowsAndBullsGame.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CowsAndBullsGame.Data
{
    public class UserStoreContext:IdentityDbContext<ApplicationUser>
    {
        public UserStoreContext(DbContextOptions<UserStoreContext> dbContextOptions )
            :base(dbContextOptions)
        {

        }
       
    }
}
