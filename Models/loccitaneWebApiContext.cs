using Microsoft.EntityFrameworkCore;

namespace loccitane_webapi.Models
{
    public class LoccitaneWebApiContext : DbContext{
        public LoccitaneWebApiContext(DbContextOptions<LoccitaneWebApiContext> options): base(options){

        }
        public DbSet<File> Files{get; set;}
        public DbSet<User> Users{get; set;}
    }
}