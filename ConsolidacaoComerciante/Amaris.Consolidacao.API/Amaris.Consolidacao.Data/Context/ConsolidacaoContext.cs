using Amaris.Consolidacao.Data.Interfaces;
using Amaris.Consolidacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Amaris.Consolidacao.Data.Context
{
    public class ConsolidacaoContext : DbContext, IDbContext
    {
        #region Ctor
#pragma warning disable CS8618
        public ConsolidacaoContext(DbContextOptions<ConsolidacaoContext> options) : base(options)
        {
        }
        #endregion

        #region Methods
        public DbConnection GetConnection()
        {
            return Database.GetDbConnection();
        }
        #endregion

        #region DbSets
        public DbSet<UserEntity> Users { get; set; }
        #endregion

        #region Override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().ToTable("AspNetUsers", "Consolidacao");
        }
        #endregion
    }
}
