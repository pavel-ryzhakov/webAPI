using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<GraphicCard> GraphicCards { get; set; } = default!;
        public DbSet<Processor> Processors { get; set; } = default!;
    

    }
}
