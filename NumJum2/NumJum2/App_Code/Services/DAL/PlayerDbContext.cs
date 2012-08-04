using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.Entity;
using NumJum2.Domain;
using NumJum2.Services;

namespace NumJum2.Services.DAL
{
    public class PlayerDbContext : DbContext
    {
        public DbSet<PlayerDb> PlayersDb { set; get; }
        public DbSet<PlayerScore> PlayerScores { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Disable lazy loading
            this.Configuration.LazyLoadingEnabled = false;

            // Force database to be rebuilt
            //Database.SetInitializer<PlayerDbContext>(new DropCreateDatabaseAlways<PlayerDbContext>());

            // Rebuild model if schema changes
            /*Database.SetInitializer<PlayerDbContext>
                (new DropCreateDatabaseIfModelChanges<PlayerDbContext>()); */
        }
    }


}