using BlazorMetas.Shared.Persistenacia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMetas.Shared
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {


    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblMetas>().HasKey(x => x.Id);

        modelBuilder.Entity<tblActividad>().HasKey(x => x.Id);
        modelBuilder.Entity<tblActividad>().HasOne(x => x.Meta).WithMany(d => d.Actividades).HasForeignKey(x => x.MetaId).IsRequired(true);

        base.OnModelCreating(modelBuilder);
    }


    public DbSet<tblMetas> tblMetas { get; set; }
    public DbSet<tblActividad> tblActividad { get; set; }


}
}

