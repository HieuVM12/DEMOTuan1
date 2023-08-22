using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<NhanVien> NhanViens { get; set; }

    }
}
