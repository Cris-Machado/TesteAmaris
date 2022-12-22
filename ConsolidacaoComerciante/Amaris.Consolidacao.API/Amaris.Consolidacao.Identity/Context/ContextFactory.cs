﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaris.Consolidacao.Identity.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var conn = "Server=(localdb)\\mssqllocaldb;Database=ConsolidacaoDb;";

            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();

            optionsBuilder.UseSqlServer(conn);
            return new IdentityContext(optionsBuilder.Options);
        }
    }
}
