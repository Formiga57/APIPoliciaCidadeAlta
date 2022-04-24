using Microsoft.EntityFrameworkCore;
using API.Models;
namespace API.Repo
{
    public class CodigosPenaisContext : DbContext
    {
        public CodigosPenaisContext(DbContextOptions<CodigosPenaisContext> options) : base(options)
        {

        }
    }
}