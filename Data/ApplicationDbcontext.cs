using Microsoft.EntityFrameworkCore;

namespace LuuTienDat_174.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    }
}