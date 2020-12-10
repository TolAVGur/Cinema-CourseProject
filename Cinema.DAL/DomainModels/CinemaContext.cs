using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Cinema.DAL.DomainModels
{
    public partial class CinemaContext : DbContext
    {
        public CinemaContext()
            : base("name=CinemaContext")
        {
        }

        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Seance> Seances { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<line> lines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasMany(e => e.Seances)
                .WithRequired(e => e.Film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hall>()
                .HasMany(e => e.lines)
                .WithRequired(e => e.Hall)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hall>()
                .HasMany(e => e.Seances)
                .WithRequired(e => e.Hall)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seance>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Seance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Visitor>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Visitor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<line>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
