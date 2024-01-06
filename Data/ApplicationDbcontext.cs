using Microsoft.EntityFrameworkCore;
using LuuTienDat_174.Models;

namespace LuuTienDat_174.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<SinhVien> SinhVien {get; set;}
        public DbSet<SinhVienHumg> SinhVienHumg {get; set;}
        
    }
}