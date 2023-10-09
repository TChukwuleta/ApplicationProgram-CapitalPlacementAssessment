using ApplicationProgram_CapitalPlacementAssessment.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApplicationProgram_CapitalPlacementAssessment.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public DbSet<ApplicationStage> ApplicationStages { get; set; }
        public DbSet<ApplicationProgram> ApplicationPrograms { get; set; }
        public DbSet<ApplicationForm> ApplicationForms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var url = configuration.GetSection("CosmosUrl").Value;
            var dbName = configuration.GetSection("CosmosDatabaseName").Value;
            var accountKey = configuration.GetSection("CosmosAccountKey").Value;
            optionsBuilder.UseCosmos(url, accountKey, dbName);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationStage>()
                .ToContainer("ApplicationStages")
                .HasPartitionKey(c => c.Id);

            modelBuilder.Entity<ApplicationProgram>()
                .ToContainer("ApplicationPrograms")
                .HasPartitionKey(c => c.Id);

            modelBuilder.Entity<ApplicationForm>()
                .ToContainer("ApplicationForms")
                .HasPartitionKey(c => c.Id);


            modelBuilder.Entity<ApplicationStage>().OwnsOne(c => c.VideoInterviewStage);
            modelBuilder.Entity<ApplicationForm>().OwnsOne(c => c.PersonalInformation);
            modelBuilder.Entity<ApplicationForm>().OwnsOne(c => c.AdditionalQuestion);
            modelBuilder.Entity<Profile>().OwnsMany(c => c.Educations);
            modelBuilder.Entity<Profile>().OwnsMany(c => c.WorkExperiences);
        }
    }
}
