using LNTU_GuideMap.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LNTU_GuideMap.Data {
    public class MapsDbContext : DbContext {
        public DbSet<Map> Maps { get; set; }

        public MapsDbContext(DbContextOptions<MapsDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
