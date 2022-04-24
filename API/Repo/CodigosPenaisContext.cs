using Microsoft.EntityFrameworkCore;
using API.Models;
namespace API.Repo
{
    public class CodigosPenaisContext : DbContext
    {
        public CodigosPenaisContext(DbContextOptions<CodigosPenaisContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<CriminalCode> CriminalCodes { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
    }
}