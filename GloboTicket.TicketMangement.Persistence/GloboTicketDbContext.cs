using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence
{
    public class GloboTicketDbContext: DbContext
    {
        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);

            //seed data, added through migrations
            var concertGuid = Guid.Parse("{a77119ed-8d1e-4945-844f-7ca3cb151992}");
            var musicalGuid = Guid.Parse("{bd20c07f-5937-4ea1-9104-ab80780ad4da}");
            var playGuid = Guid.Parse("{9bbe2c6c-2023-4130-8c25-bebd3133e471}");
            var conferenceguid = Guid.Parse("{67267b4e-435e-4c53-9d3c-b07c294b75cb}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = conferenceguid,
                Name = "Conferences"
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{325b05ca-9d09-4be7-9d88-ff7052c1f40c}"),
                Name = "John Egbbert Live",
                Price = 65,
                Artist = "John Egbert",
                Date = DateTime.Now.AddMonths(6),
                Description = "Join John for his farwell tour across 15 continetns.John really needs no introduction since he has already mesmerized the world with his banjo.",
                ImageUrl = "https://image.jpg",
                CategoryId = concertGuid,
            });

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
