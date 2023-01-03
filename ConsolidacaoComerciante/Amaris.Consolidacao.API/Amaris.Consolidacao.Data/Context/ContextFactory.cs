using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Amaris.Consolidacao.Data.Context
{
    public class ConnectionFactory : IDesignTimeDbContextFactory<ConsolidacaoContext>
    {
        public ConsolidacaoContext CreateDbContext(string[] args)
        {
            var conn = "Server=(localdb)\\mssqllocaldb;Database=ConsolidacaoDb;";
            var optionsBuilder = new DbContextOptionsBuilder<ConsolidacaoContext>();

            optionsBuilder.UseSqlServer(conn);
            return new ConsolidacaoContext(optionsBuilder.Options);
        }
    }
}
