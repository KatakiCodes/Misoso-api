using Microsoft.EntityFrameworkCore;
using Misoso.api.Entities;

namespace Misoso.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<SubtaskItem> SubTasks { get; set; }
    }
}
