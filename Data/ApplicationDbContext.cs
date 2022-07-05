using Microsoft.EntityFrameworkCore;
using BookStoreWeb.Models;

namespace BookStoreWeb.Data
{
    //create appliaction context with entity framework
    public class ApplicationDbContext : DbContext
    {
        //pass in the options to base class which is (dbcontext)
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //create a set for the model items
        public DbSet<Category> Categories { get; set;  }
    }
}
