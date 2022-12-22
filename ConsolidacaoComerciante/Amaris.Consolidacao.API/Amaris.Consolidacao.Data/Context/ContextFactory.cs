using Amaris.Consolidacao.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
