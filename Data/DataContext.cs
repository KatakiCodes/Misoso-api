using Microsoft.EntityFrameworkCore;
using Misoso.api.Entities;

namespace Misoso.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<User> Users;
        public DbSet<TaskItem> Tasks;
        public DbSet<SubtaskItem> SubTasks;
    }
}
