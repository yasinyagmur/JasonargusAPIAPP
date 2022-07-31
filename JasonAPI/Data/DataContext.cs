using Microsoft.EntityFrameworkCore;

namespace JasonAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ArgusUser> ArgusUsers { get; set; }
    }
}
