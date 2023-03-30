using demo.Model;
using Microsoft.EntityFrameworkCore;

namespace demo.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
    }
}
